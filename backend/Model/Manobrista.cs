using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkinglotApp.Model
{
  [Table("manobrista")]
  public class Manobrista
  {
    [Key,Column("codigo")]
    public long Codigo { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("cpf")]
    public string Cpf { get; set; }
    [Column("data_nascimento")]
    public DateTime DataNascimento { get; set; }

    public List<Manobra> Manobras { get; set; }
  }
}
