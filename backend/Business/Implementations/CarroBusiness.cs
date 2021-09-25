using ParkinglotApp.Model;
using ParkinglotApp.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace ParkinglotApp.Business.Implementations
{
  public class CarroBusiness : ICarroBusiness
  {
    private readonly IGenericoRepository<Carro> _repository;

    public CarroBusiness(IGenericoRepository<Carro> repository)
    {
      _repository = repository;
    }

    public Carro Atualizar(Carro carro)
    {
      return _repository.Atualizar(carro);
    }

    public Carro BuscarPorId(long codigo)
    {
      return _repository.BuscarPorId(codigo, x => x.Manobras);
    }

    public Carro Criar(Carro carro)
    {
      return _repository.Criar(carro);
    }

    public void Deletar(long codigo)
    {
      _repository.Deletar(codigo);
    }

    public List<Carro> Listar()
    {
      return _repository.Listar(x => x.Manobras);
    }
  }
}
