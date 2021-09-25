using ParkinglotApp.Model;
using ParkinglotApp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkinglotApp.Repository.Implementations
{
  public class ManobraRepository : IManobraRepository
  {
    private MySqlContext _context;

    public ManobraRepository(MySqlContext context)
    {
      _context = context;
    }

    private bool Existe(long codigo)
    {
      return _context.Manobras.Any(x => x.Codigo.Equals(codigo));
    }

    public Manobra Atualizar(Manobra manobra)
    {
      if (!Existe(manobra.Codigo)) return null;
      var result = _context.Manobras.SingleOrDefault(x => x.Codigo.Equals(manobra.Codigo));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(manobra);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }

      return manobra;
    }

    public Manobra BuscarPorId(long codigo)
    {
      return _context.Manobras.SingleOrDefault(x => x.Codigo.Equals(codigo));
    }

    public Manobra Criar(Manobra manobra)
    {
      try
      {
        _context.Add(manobra);
        _context.SaveChanges();
      }
      catch (Exception)
      {
        throw;
      }
      return manobra;
    }

    public void Deletar(long codigo)
    {
      var result = _context.Manobras.SingleOrDefault(x => x.Codigo.Equals(codigo));
      if (result != null)
      {
        try
        {
          _context.Manobras.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    public List<Manobra> Listar()
    {
      return _context.Manobras.ToList();
    }
  }
}
