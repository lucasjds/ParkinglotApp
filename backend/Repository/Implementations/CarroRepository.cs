using ParkinglotApp.Model;
using ParkinglotApp.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Repository.Implementations
{
  public class CarroRepository : ICarroRepository
  {
    private MySqlContext _context;

    public CarroRepository(MySqlContext context)
    {
      _context = context;
    }

    private bool Existe(long codigo)
    {
      return _context.Carros.Any(x => x.Codigo.Equals(codigo));
    }

    public Carro Atualizar(Carro carro)
    {
      if (!Existe(carro.Codigo)) return null;
      var result = _context.Carros.SingleOrDefault(x => x.Codigo.Equals(carro.Codigo));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(carro);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }

      return carro;
    }

    public Carro BuscarPorId(long codigo)
    {
      return _context.Carros.SingleOrDefault(x => x.Codigo.Equals(codigo));
    }

    public Carro Criar(Carro carro)
    {
      try
      {
        _context.Add(carro);
        _context.SaveChanges();
      }
      catch (Exception)
      {
        throw;
      }
      return carro;
    }

    public void Deletar(long codigo)
    {
      var result = _context.Carros.SingleOrDefault(x => x.Codigo.Equals(codigo));
      if (result != null)
      {
        try
        {
          _context.Carros.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    public List<Carro> Listar()
    {
      return _context.Carros.ToList();
    }
  }
}
