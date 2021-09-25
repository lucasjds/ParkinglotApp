using ParkinglotApp.Model;
using System;

namespace ParkinglotApp.Data.VO
{
  public class ManobraVO
  {
    public long Codigo { get; set; }
    public long CodigoManobrista { get; set; }
    public long CodigoCarro { get; set; }
    public DateTime DataHoraManobra { get; set; }
    public Manobrista Manobrista { get; set; }
    public Carro Carro { get; set; }
  }
}