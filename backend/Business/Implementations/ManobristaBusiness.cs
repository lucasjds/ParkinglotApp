using ParkinglotApp.Model;
using ParkinglotApp.Repository.Generic;
using System.Collections.Generic;

namespace ParkinglotApp.Business.Implementations
{
  public class ManobristaBusiness : IManobristaBusiness
  {
    private readonly IGenericoRepository<Manobrista> _repository;

    public ManobristaBusiness(IGenericoRepository<Manobrista> repository)
    {
      _repository = repository;
    }

    public Manobrista Atualizar(Manobrista manobrista)
    {
      return _repository.Atualizar(manobrista);
    }

    public Manobrista BuscarPorId(long codigo)
    {
      return _repository.BuscarPorId(codigo, x => x.Manobras);
    }

    public Manobrista Criar(Manobrista manobrista)
    {
      return _repository.Criar(manobrista);
    }

    public void Deletar(long codigo)
    {
      _repository.Deletar(codigo);
    }

    public List<Manobrista> Listar()
    {
      return _repository.Listar(x => x.Manobras);
    }
  }
}
