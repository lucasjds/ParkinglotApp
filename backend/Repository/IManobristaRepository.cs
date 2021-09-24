﻿using ParkinglotApp.Model;
using System.Collections.Generic;

namespace ParkinglotApp.Services
{
  public interface IManobristaRepository
  {
    Manobrista Criar(Manobrista manobrista);
    Manobrista BuscarPorId(long id);
    List<Manobrista> Listar();
    Manobrista Atualizar(Manobrista manobrista);
    void Deletar(long id);
  }
}