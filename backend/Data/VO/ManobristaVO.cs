using ParkinglotApp.Hypermedia;
using ParkinglotApp.Hypermedia.Abstract;
using ParkinglotApp.Model;
using System;
using System.Collections.Generic;

namespace ParkinglotApp.Data.VO
{
  public class ManobristaVO : ISupportHypermedia
  {
    public long Codigo { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public IEnumerable<ManobraVO> Manobras { get; set; }
    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
  }
}
