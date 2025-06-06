using System;
using System.Collections.Generic;
using Gerenciador_Catalogo_Filmes.Model;
namespace Gerenciador_Catalogo_Filmes.Interfaces;

public interface IFilmeRepository : IRepository<Filme>
{
    IEnumerable<Filme> ObterPorGenero(string genero);
}
