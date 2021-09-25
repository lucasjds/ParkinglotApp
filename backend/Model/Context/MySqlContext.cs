using Microsoft.EntityFrameworkCore;

namespace ParkinglotApp.Model.Context
{
  public class MySqlContext : DbContext
  {
    public MySqlContext() { }
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    public DbSet<Manobrista> Manobristas { get; set; }
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Manobra> Manobras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Manobra>()
          .HasOne(p => p.Manobrista)
          .WithMany(b => b.Manobras);

      modelBuilder.Entity<Manobra>()
         .HasOne(p => p.Carro)
         .WithMany(b => b.Manobras);
    }
  }
}
