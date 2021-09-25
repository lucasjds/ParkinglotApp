using ParkinglotApp.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ParkinglotApp.Hypermedia.Filter
{
  public class HyperMediaFilterOptions
  {
    public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
  }
}
