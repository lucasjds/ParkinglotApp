using ParkinglotApp.Model;
using System;
using System.Collections.Generic;

namespace ParkinglotApp.Data.VO
{
  public class ManobristaVO
  {
    public long Codigo { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public IEnumerable<Manobra> Manobras { get; set; }
  }
}
