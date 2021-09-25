using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Repository
{
  public interface ICarroRepository
  {
    Carro Criar(Carro carro);
    Carro BuscarPorId(long id);
    List<Carro> Listar();
    Carro Atualizar(Carro carro);
    void Deletar(long id);
  }
}
