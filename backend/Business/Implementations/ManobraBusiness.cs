using ParkinglotApp.Model;
using ParkinglotApp.Repository.Generic;
using System.Collections.Generic;

namespace ParkinglotApp.Business.Implementations
{
  public class ManobraBusiness : IManobraBusiness
  {
    private readonly IGenericoRepository<Manobra> _repository;

    public ManobraBusiness(IGenericoRepository<Manobra> repository)
    {
      _repository = repository;
    }

    public Manobra Atualizar(Manobra manobra)
    {
      return _repository.Atualizar(manobra);
    }

    public Manobra BuscarPorId(long id)
    {
      return _repository.BuscarPorId(id, x => x.Manobrista, x => x.Carro);
    }

    public Manobra Criar(Manobra manobra)
    {
      return _repository.Criar(manobra);
    }

    public void Deletar(long id)
    {
      _repository.Deletar(id);
    }

    public List<Manobra> Listar()
    {
      return _repository.Listar(x => x.Manobrista, x => x.Carro);
    }
  }
}
