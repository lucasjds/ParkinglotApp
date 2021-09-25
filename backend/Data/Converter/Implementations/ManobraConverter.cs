using ParkinglotApp.Data.Converter.Contract;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Data.Converter.Implementations
{
  public class ManobraConverter : IParser<ManobraVO, Manobra>, IParser<Manobra, ManobraVO>
  {
  
    public Manobra Parse(ManobraVO origin)
    {
      if (origin == null) return null;
      
      return new Manobra
      {
        Codigo = origin.Codigo,
        CodigoCarro = origin.CodigoCarro,
        CodigoManobrista = origin.CodigoManobrista,
        DataHoraManobra = origin.DataHoraManobra,
        Carro = (origin.Carro),
        Manobrista = (origin.Manobrista),
      };
    }

    public List<Manobra> Parse(List<ManobraVO> origin)
    {
      if (origin == null) return null;
      return origin.Select(item => Parse(item)).ToList();
    }

    public ManobraVO Parse(Manobra origin)
    {
      if (origin == null) return null;
      return new ManobraVO
      {
        Codigo = origin.Codigo,
        CodigoCarro = origin.CodigoCarro,
        CodigoManobrista = origin.CodigoManobrista,
        DataHoraManobra = origin.DataHoraManobra,
        Carro = (origin.Carro),
        Manobrista = (origin.Manobrista),
      };
    }

    public List<ManobraVO> Parse(List<Manobra> origin)
    {
      if (origin == null) return null;
      return origin.Select(item => Parse(item)).ToList();
    }
  }
}
