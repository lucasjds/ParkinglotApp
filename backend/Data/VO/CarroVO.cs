using ParkinglotApp.Hypermedia;
using ParkinglotApp.Hypermedia.Abstract;
using System.Collections.Generic;

namespace ParkinglotApp.Data.VO
{
  public class CarroVO : ISupportHypermedia
  {
    public long Codigo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public IEnumerable<ManobraVO> Manobras { get; set; }
    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
  }
}
