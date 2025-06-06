using System;
using Gerenciador_Catalogo_Filmes.Interfaces;
using Gerenciador_Catalogo_Filmes.Model;
namespace Gerenciador_Catalogo_Filmes.Implementacoes;

public class FilmeJsonRepository : GenericJsonRepository<Filme>, IFilmeRepository
{
    public FilmeJsonRepository(string caminhoArquivo = "filmes.json")
        : base(caminhoArquivo) { }

    public IEnumerable<Filme> ObterPorGenero(string genero)
    {
        return ObterTodos() 
            .Where(f => f.Genero != null && f.Genero.Equals(genero, StringComparison.OrdinalIgnoreCase));
    }
}
