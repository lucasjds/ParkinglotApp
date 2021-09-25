using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model
{
  public class Manobra
  {
    [Key, Column("codigo")]
    public long Codigo { get; set; }
    [Column("codigo_manobrista")]
    public long CodigoManobrista { get; set; }
    [Column("codigo_carro")]
    public long CodigoCarro { get; set; }
    [Column("data_hora_manobra")]
    public DateTime DataHoraManobra { get; set; }

    public Manobrista Manobrista { get; set; }
    public Carro Carro { get; set; }
  }
}
