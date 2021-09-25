using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Business
{
  public interface IManobraBusiness
  {
    Manobra Criar(Manobra manobra);
    Manobra BuscarPorId(long id);
    List<Manobra> Listar();
    Manobra Atualizar(Manobra manobra);
    void Deletar(long id);
  }
}
