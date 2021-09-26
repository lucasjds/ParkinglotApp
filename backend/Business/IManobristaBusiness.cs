using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Utils;
using ParkinglotApp.Model;
using System.Collections.Generic;

namespace ParkinglotApp.Business
{
  public interface IManobristaBusiness
  {
    ManobristaVO Criar(ManobristaVO manobrista);
    ManobristaVO BuscarPorId(long id);
    List<ManobristaVO> Listar();
    ManobristaVO Atualizar(ManobristaVO manobrista);
    void Deletar(long id);
    PagedSearchVO<ManobristaVO> BuscarPorPaginacao(string sortDirection, int pageSize, int page);
  }
}
