using Microsoft.EntityFrameworkCore;
using ParkinglotApp.Model.Base;
using ParkinglotApp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParkinglotApp.Repository.Generic
{
  public class GenericoRepository<T> : IGenericoRepository<T> where T : EntidadeBase
  {
    protected MySqlContext _context;
    private DbSet<T> dataset;

    public GenericoRepository(MySqlContext context)
    {
      _context = context;
      dataset = context.Set<T>();
    }

    public T Atualizar(T item)
    {
      var result = dataset.SingleOrDefault(x => x.Codigo.Equals(item.Codigo));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(item);
          _context.SaveChanges();
          return result;
        }
        catch (Exception)
        {
          throw;
        }
      }
      else
      {
        return null;
      }
    }

    public T BuscarPorId(long cod, params Expression<Func<T, object>>[] childrens)
    {
      childrens.ToList().ForEach(x => dataset.Include(x).Load());
      return dataset.SingleOrDefault(x => x.Codigo.Equals(cod));
    }

    public T Criar(T e)
    {
      try
      {
        dataset.Add(e);
        _context.SaveChanges();
        return e;
      }
      catch (Exception)
      {
        throw;
      }
    }

    public void Deletar(long cod)
    {
      var result = dataset.SingleOrDefault(x => x.Codigo.Equals(cod));
      if (result != null)
      {
        try
        {
          dataset.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    public List<T> Listar(params Expression<Func<T, object>>[] childrens)
    {
      
      childrens.ToList().ForEach(x => dataset.Include(x).Load());
      return dataset.ToList();
    }

  }
}
