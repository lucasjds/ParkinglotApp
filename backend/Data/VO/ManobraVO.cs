using ParkinglotApp.Hypermedia;
using ParkinglotApp.Hypermedia.Abstract;
using ParkinglotApp.Model;
using System;
using System.Collections.Generic;

namespace ParkinglotApp.Data.VO
{
  public class ManobraVO : ISupportHypermedia
  {
    public long Codigo { get; set; }
    public long CodigoManobrista { get; set; }
    public long CodigoCarro { get; set; }
    public DateTime DataHoraManobra { get; set; }
    public Manobrista Manobrista { get; set; }
    public Carro Carro { get; set; }
    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
  }
}