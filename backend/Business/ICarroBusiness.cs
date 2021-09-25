using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Utils;
using System.Collections.Generic;

namespace ParkinglotApp.Business
{
  public interface ICarroBusiness
  {
    CarroVO Criar(CarroVO carro);
    CarroVO BuscarPorId(long id);
    List<CarroVO> Listar();
    CarroVO Atualizar(CarroVO carro);
    void Deletar(long id);
    PagedSearchVO<CarroVO> BuscarPorPaginacao(string sortDirection, int pageSize, int page);
  }
}
