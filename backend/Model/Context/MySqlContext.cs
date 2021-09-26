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
      modelBuilder.Entity<Manobrista>()
          .HasMany<Manobra>(g => g.Manobras)
          .WithOne(s => s.Manobrista)
          .HasForeignKey(s => s.CodigoManobrista)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Carro>()
          .HasMany<Manobra>(g => g.Manobras)
          .WithOne(s => s.Carro)
          .HasForeignKey(s => s.CodigoCarro)
          .OnDelete(DeleteBehavior.Cascade); ;
    }
  }
}
