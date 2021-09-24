using ParkinglotApp.Model;
using ParkinglotApp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkinglotApp.Services.Implementations
{
  public class ManobristaRepository : IManobristaRepository
  {
    private MySqlContext _context;

    public ManobristaRepository(MySqlContext context)
    {
      _context = context;
    }

    private bool Existe(long codigo)
    {
      return _context.Manobristas.Any(x => x.Codigo.Equals(codigo));
    }

    public Manobrista Atualizar(Manobrista manobrista)
    {
      if (!Existe(manobrista.Codigo)) return new Manobrista();
      var result = _context.Manobristas.SingleOrDefault(x => x.Codigo.Equals(manobrista.Codigo));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(manobrista);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }

      return manobrista;
    }

    public Manobrista BuscarPorId(long codigo)
    {
      return _context.Manobristas.SingleOrDefault(x => x.Codigo.Equals(codigo));
    }

    public Manobrista Criar(Manobrista manobrista)
    {
      try
      {
        _context.Add(manobrista);
        _context.SaveChanges();
      }
      catch (Exception)
      {
        throw;
      }
      return manobrista;
    }

    public void Deletar(long codigo)
    {
      var result = _context.Manobristas.SingleOrDefault(x => x.Codigo.Equals(codigo));
      if (result != null)
      {
        try
        {
          _context.Manobristas.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    public List<Manobrista> Listar()
    {
      return _context.Manobristas.ToList();
    }
  }
}
