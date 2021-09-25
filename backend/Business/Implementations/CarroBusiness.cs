using ParkinglotApp.Model;
using ParkinglotApp.Repository;
using System.Collections.Generic;

namespace ParkinglotApp.Business.Implementations
{
  public class CarroBusiness : ICarroBusiness
  {
    private readonly ICarroRepository _repository;

    public CarroBusiness(ICarroRepository repository)
    {
      _repository = repository;
    }

    public Carro Atualizar(Carro carro)
    {
      return _repository.Atualizar(carro);
    }

    public Carro BuscarPorId(long codigo)
    {
      return _repository.BuscarPorId(codigo);
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
      return _repository.Listar();
    }
  }
}
