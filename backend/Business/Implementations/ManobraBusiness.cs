using ParkinglotApp.Data.Converter.Implementations;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using ParkinglotApp.Repository.Generic;
using System.Collections.Generic;

namespace ParkinglotApp.Business.Implementations
{
  public class ManobraBusiness : IManobraBusiness
  {
    private readonly IGenericoRepository<Manobra> _repository;
    private readonly ManobraConverter _converter;

    public ManobraBusiness(IGenericoRepository<Manobra> repository)
    {
      _repository = repository;
      _converter = new ManobraConverter();
    }

    public ManobraVO Atualizar(ManobraVO manobra)
    {
      var entity = _converter.Parse(manobra);
      entity = _repository.Atualizar(entity);
      return _converter.Parse(entity);
    }

    public ManobraVO BuscarPorId(long id)
    {
      return _converter.Parse(_repository.BuscarPorId(id, x => x.Manobrista, x => x.Carro));
    }

    public ManobraVO Criar(ManobraVO manobra)
    {
      var entity = _converter.Parse(manobra);
      entity = _repository.Criar(entity);
      return _converter.Parse(entity);
    }

    public void Deletar(long id)
    {
      _repository.Deletar(id);
    }

    public List<ManobraVO> Listar()
    {
      return _converter.Parse(_repository.Listar(x => x.Manobrista, x => x.Carro));
    }
  }
}
