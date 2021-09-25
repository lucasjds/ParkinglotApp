using ParkinglotApp.Data.Converter.Implementations;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Utils;
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

    public PagedSearchVO<CarroVO> BuscarPorPaginacao(string sortDirection, int pageSize, int page)
    {
      var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
      var size = (pageSize < 1) ? 10 : pageSize;
      var offset = page > 0 ? (page - 1) * size : 0;

      string query = @"select * from carro c where 1 = 1 ";
      query += $" order by c.modelo {sort} limit {size} offset {offset} ";
      string countQuery = @"select count(*) from carro c where 1 = 1 ";
      var carros = _repository.BuscarPorPaginacao(query);
      int totalResults = _repository.ObterContagem(countQuery);

      return new PagedSearchVO<CarroVO>
      {
        CurrentPage = page,
        List = _converter.Parse(carros),
        PageSize = size,
        SortDirections = sort,
        TotalResults = totalResults
      };
    }
  }
}
