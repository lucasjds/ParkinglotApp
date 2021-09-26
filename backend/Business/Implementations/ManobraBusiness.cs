using ParkinglotApp.Data.Converter.Implementations;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Utils;
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

    public PagedSearchVO<ManobraVO> BuscarPorPaginacao(string sortDirection, int pageSize, int page)
    {
      var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
      var size = (pageSize < 1) ? 10 : pageSize;
      var offset = page > 0 ? (page - 1) * size : 0;

      string query = @"select * from manobra c where 1 = 1 ";
      query += $" order by c.codigo {sort} limit {size} offset {offset} ";
      string countQuery = @"select count(*) from manobra c where 1 = 1 ";
      var manobras = _repository.BuscarPorPaginacao(query, x => x.Carro, x => x.Manobrista);
      int totalResults = _repository.ObterContagem(countQuery);

      return new PagedSearchVO<ManobraVO>
      {
        CurrentPage = page,
        List = _converter.Parse(manobras),
        PageSize = size,
        SortDirections = sort,
        TotalResults = totalResults
      };
    }
  }
}
