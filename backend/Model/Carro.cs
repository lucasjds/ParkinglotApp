using ParkinglotApp.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model
{
  [Table("carro")]
  public class Carro : EntidadeBase
  {
    [Column("marca")]
    public string Marca { get; set; }
    [Column("modelo")]
    public string Modelo { get; set; }
    [Column("placa")]
    public string Placa { get; set; }
    public virtual IEnumerable<Manobra> Manobras { get; set; }
  }
}
