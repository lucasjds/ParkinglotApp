using ParkinglotApp.Data.Converter.Contract;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Data.Converter.Implementations
{
  public class CarroConverter : IParser<CarroVO, Carro>, IParser<Carro, CarroVO>
  {

    public Carro Parse(CarroVO origin)
    {
      if (origin == null) return null;
      ManobraConverter manobraConverter = new ManobraConverter();
      return new Carro
      {
        Codigo = origin.Codigo,
        Marca = origin.Marca,
        Modelo = origin.Modelo,
        Placa = origin.Placa,
        Manobras =  manobraConverter.Parse(origin.Manobras?.ToList()),
      };
    }

    public List<Carro> Parse(List<CarroVO> origin)
    {
      if (origin == null) return null;
      return origin.Select(item => Parse(item)).ToList();
    }

    public CarroVO Parse(Carro origin)
    {
      if (origin == null) return null;
      ManobraConverter manobraConverter = new ManobraConverter();
      return new CarroVO
      {
        Codigo = origin.Codigo,
        Marca = origin.Marca,
        Modelo = origin.Modelo,
        Placa = origin.Placa,
        Manobras = manobraConverter.Parse(origin.Manobras?.ToList()),
      };
    }

    public List<CarroVO> Parse(List<Carro> origin)
    {
      if (origin == null) return null;
      return origin.Select(item => Parse(item)).ToList();
    }
  }
}
