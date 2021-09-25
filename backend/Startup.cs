using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ParkinglotApp.Business;
using ParkinglotApp.Business.Implementations;
using ParkinglotApp.Hypermedia.Enricher;
using ParkinglotApp.Hypermedia.Filter;
using ParkinglotApp.Model.Context;
using ParkinglotApp.Repository.Generic;
using Serilog;
using System.Collections.Generic;

namespace ParkinglotApp
{
  public class Startup
  {
    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      Configuration = configuration;
      Environment = environment;

      Log.Logger = new LoggerConfiguration()
                          .WriteTo.Console()
                          .CreateLogger();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options => options.AddDefaultPolicy(builder =>
      {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
      }));
      services.AddControllers();
      var connection = Configuration["MySqlConnection:MySqlConnectionString"];
      services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

      services.AddControllersWithViews()
              .AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      if (Environment.IsDevelopment())
      {
        MigrateDatabase(connection);
      }
      var filterOptions = new HyperMediaFilterOptions();
      filterOptions.ContentResponseEnricherList.Add(new CarroEnricher());
      filterOptions.ContentResponseEnricherList.Add(new ManobraEnricher());
      filterOptions.ContentResponseEnricherList.Add(new ManobristaEnricher());
      services.AddSingleton(filterOptions);

      services.AddApiVersioning();
      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1",
          new OpenApiInfo
          {
            Title = "Parkinglot Estapar Web API",
            Version = "v1",
            Description = "Parkinglot Estapar Web API",
            Contact = new OpenApiContact
            {
              Name = "Lucas Souza",
              Url = new System.Uri("https://github.com/lucasjds"),
            }
          });
      });
      services.AddScoped<IManobristaBusiness, ManobristaBusiness>();
      services.AddScoped<ICarroBusiness, CarroBusiness>();
      services.AddScoped<IManobraBusiness, ManobraBusiness>();
      services.AddScoped(typeof(IGenericoRepository<>), typeof(GenericoRepository<>));

      
    }

    private void MigrateDatabase(string connection)
    {
      try
      {
        var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
        var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
        {
          Locations = new List<string> { "db/migrations", "db/dataset" },
          IsEraseDisabled = true,
        };
        evolve.Migrate();
      }
      catch (System.Exception ex)
      {
        Log.Error("Database migration failed", ex);
        throw;
      }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseCors();
      app.UseRouting();

      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Parkinglot APP");
      });

      var option = new RewriteOptions();
      option.AddRedirect("^$", "swagger");
      app.UseRewriter(option);

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
      });
    }
  }
}
