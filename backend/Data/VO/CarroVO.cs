using ParkinglotApp.Model;
using System.Collections.Generic;

namespace ParkinglotApp.Data.VO
{
  public class CarroVO
  {
    public long Codigo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Placa { get; set; }
    public IEnumerable<ManobraVO> Manobras { get; set; }
  }
}
