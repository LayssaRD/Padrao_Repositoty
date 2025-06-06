using System;
using Gerenciador_Catalogo_Filmes.Entidade;
namespace Gerenciador_Catalogo_Filmes.Model;

public class Filme : IEntidade
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; } = string.Empty;
    public string Diretor { get; set; } = string.Empty;
    public int AnoLancamento { get; set; }
    public string Genero { get; set; } = string.Empty;

}
