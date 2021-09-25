using ParkinglotApp.Data.Converter.Implementations;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using ParkinglotApp.Repository.Generic;
using System.Collections.Generic;

namespace ParkinglotApp.Business.Implementations
{
  public class ManobristaBusiness : IManobristaBusiness
  {
    private readonly IGenericoRepository<Manobrista> _repository;
    private readonly ManobristaConverter _converter;

    public ManobristaBusiness(IGenericoRepository<Manobrista> repository)
    {
      _repository = repository;
      _converter = new ManobristaConverter();
    }

    public ManobristaVO Atualizar(ManobristaVO manobrista)
    {
      var entity = _converter.Parse(manobrista);
      entity = _repository.Atualizar(entity);
      return _converter.Parse(entity);
    }

    public ManobristaVO BuscarPorId(long codigo)
    {
      return _converter.Parse(_repository.BuscarPorId(codigo, x => x.Manobras));
    }

    public ManobristaVO Criar(ManobristaVO manobrista)
    {
      var entity = _converter.Parse(manobrista);
      entity = _repository.Criar(entity);
      return _converter.Parse(entity);
    }

    public void Deletar(long codigo)
    {
      _repository.Deletar(codigo);
    }

    public List<ManobristaVO> Listar()
    {
      return _converter.Parse(_repository.Listar(x => x.Manobras));
    }
  }
}
