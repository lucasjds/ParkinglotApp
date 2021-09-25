using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Business
{
  public interface IManobraBusiness
  {
    ManobraVO Criar(ManobraVO manobra);
    ManobraVO BuscarPorId(long id);
    List<ManobraVO> Listar();
    ManobraVO Atualizar(ManobraVO manobra);
    void Deletar(long id);
  }
}
