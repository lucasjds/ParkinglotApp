using ParkinglotApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParkinglotApp.Repository.Generic
{
  public interface IGenericoRepository<T> where T : EntidadeBase
  {
    T Criar(T e);
    T BuscarPorId(long cod, params Expression<Func<T, object>>[] childrens);
    List<T> Listar(params Expression<Func<T, object>>[] childrens);
    T Atualizar(T e);
    void Deletar(long cod);
  }
}
