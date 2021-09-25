using ParkinglotApp.Data.Converter.Contract;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace ParkinglotApp.Data.Converter.Implementations
{
  public class ManobristaConverter : IParser<ManobristaVO, Manobrista>, IParser<Manobrista, ManobristaVO>
  {
   
    public Manobrista Parse(ManobristaVO origin)
    {
      if (origin == null) return null;
      ManobraConverter manobraConverter = new ManobraConverter();
      return new Manobrista
      {
        Codigo = origin.Codigo,
        Cpf = origin.Cpf,
        DataNascimento = origin.DataNascimento,
        Nome = origin.Nome,
        Manobras = manobraConverter.Parse(origin.Manobras?.ToList()),
      };
    }

    public List<Manobrista> Parse(List<ManobristaVO> origin)
    {
      if (origin == null) return null;
      return origin.Select(item => Parse(item)).ToList();
    }

    public ManobristaVO Parse(Manobrista origin)
    {
      if (origin == null) return null;
      ManobraConverter manobraConverter = new ManobraConverter();
      return new ManobristaVO
      {
        Codigo = origin.Codigo,
        Cpf = origin.Cpf,
        DataNascimento = origin.DataNascimento,
        Nome = origin.Nome,
        Manobras = manobraConverter.Parse(origin.Manobras?.ToList()),
      };
    }

    public List<ManobristaVO> Parse(List<Manobrista> origin)
    {
      if (origin == null) return null;
      return origin.Select(item => Parse(item)).ToList();
    }
  }
}
