using ParkinglotApp.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model
{
  [Table("manobrista")]
  public class Manobrista : EntidadeBase
  {
    [Column("nome")]
    public string Nome { get; set; }
    [Column("cpf")]
    public string Cpf { get; set; }
    [Column("data_nascimento")]
    public DateTime DataNascimento { get; set; }
    public virtual IEnumerable<Manobra> Manobras { get; set; }
  }
}
