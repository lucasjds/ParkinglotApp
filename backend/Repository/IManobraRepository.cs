using ParkinglotApp.Model;
using System.Collections.Generic;

namespace ParkinglotApp.Repository
{
  public interface IManobraRepository
  {
    Manobra Criar(Manobra manobra);
    Manobra BuscarPorId(long id);
    List<Manobra> Listar();
    Manobra Atualizar(Manobra manobra);
    void Deletar(long id);
  }
}
