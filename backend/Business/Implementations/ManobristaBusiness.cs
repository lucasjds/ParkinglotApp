using ParkinglotApp.Model;
using ParkinglotApp.Model.Context;
using ParkinglotApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkinglotApp.Business.Implementations
{
  public class ManobristaBusiness : IManobristaBusiness
  {
    private readonly IManobristaRepository _repository;

    public ManobristaBusiness(IManobristaRepository repository)
    {
      _repository = repository;
    }

    public Manobrista Atualizar(Manobrista manobrista)
    {
      return _repository.Atualizar(manobrista);
    }

    public Manobrista BuscarPorId(long codigo)
    {
      return _repository.BuscarPorId(codigo);
    }

    public Manobrista Criar(Manobrista manobrista)
    {
      return _repository.Criar(manobrista);
    }

    public void Deletar(long codigo)
    {
      _repository.Deletar(codigo);
    }

    public List<Manobrista> Listar()
    {
      return _repository.Listar();
    }
  }
}
