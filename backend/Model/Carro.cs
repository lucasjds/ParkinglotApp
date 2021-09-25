using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model
{
  public class Carro
  {
    [Key, Column("codigo")]
    public long Codigo { get; set; }
    [Column("marca")]
    public string Marca { get; set; }
    [Column("modelo")]
    public string Modelo { get; set; }
    [Column("placa")]
    public string Placa { get; set; }
    public List<Manobra> Manobras { get; set; }
  }
}
