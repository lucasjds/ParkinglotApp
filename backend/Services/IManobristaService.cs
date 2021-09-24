using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Services
{
  public interface IManobristaService
  {
    Manobrista Criar(Manobrista manobrista);
    Manobrista BuscarPorId(long id);
    List<Manobrista> Listar();
    Manobrista Atualizar(Manobrista manobrista);
    void Deletar(long id);
  }
}
