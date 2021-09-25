using ParkinglotApp.Data.Converter.Implementations;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using ParkinglotApp.Repository.Generic;
using System.Collections.Generic;

namespace ParkinglotApp.Business.Implementations
{
  public class CarroBusiness : ICarroBusiness
  {
    private readonly IGenericoRepository<Carro> _repository;
    private readonly CarroConverter _converter;

    public CarroBusiness(IGenericoRepository<Carro> repository)
    {
      _repository = repository;
      _converter = new CarroConverter();
    }

    public CarroVO Atualizar(CarroVO carro)
    {
      var entity = _converter.Parse(carro);
      entity = _repository.Atualizar(entity);
      return _converter.Parse(entity);
    }

    public CarroVO BuscarPorId(long codigo)
    {
      return _converter.Parse(_repository.BuscarPorId(codigo, x => x.Manobras));
    }

    public CarroVO Criar(CarroVO carro)
    {
      var entity = _converter.Parse(carro);
      entity = _repository.Criar(entity);
      return _converter.Parse(entity);
    }

    public void Deletar(long codigo)
    {
      _repository.Deletar(codigo);
    }

    public List<CarroVO> Listar()
    {
      return _converter.Parse(_repository.Listar(x => x.Manobras));
    }
  }
}
