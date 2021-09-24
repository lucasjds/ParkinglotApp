﻿using Microsoft.EntityFrameworkCore;

namespace ParkinglotApp.Model.Context
{
  public class MySqlContext : DbContext
  {
    public MySqlContext() { }
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
    public DbSet<Manobrista> Manobristas { get; set; }
  }
}
