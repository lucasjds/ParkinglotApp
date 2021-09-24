using ParkinglotApp.Model;
using System.Collections.Generic;

namespace ParkinglotApp.Business
{
  public interface IManobristaBusiness
  {
    Manobrista Criar(Manobrista manobrista);
    Manobrista BuscarPorId(long id);
    List<Manobrista> Listar();
    Manobrista Atualizar(Manobrista manobrista);
    void Deletar(long id);
  }
}
