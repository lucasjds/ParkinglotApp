using ParkinglotApp.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model
{
  [Table("manobra")]
  public class Manobra : EntidadeBase
  {
    [Column("codigo_manobrista")]
    [ForeignKey("manobra_ibfk_2")]
    public long CodigoManobrista { get; set; }
    [Column("codigo_carro")]
    [ForeignKey("manobra_ibfk_1")]
    public long CodigoCarro { get; set; }
    [Column("data_hora_manobra")]
    public DateTime DataHoraManobra { get; set; }

    public virtual Manobrista Manobrista { get; set; }
    public virtual Carro Carro { get; set; }
  }
}
