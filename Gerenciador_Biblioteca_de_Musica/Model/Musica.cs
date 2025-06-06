using Gerenciador_Biblioteca_de_Musica.Entidade;

namespace Gerenciador_Biblioteca_de_Musica.Model;

public class Musica : IEntidade
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Artista { get; set; } = string.Empty;
    public string Album { get; set; } = string.Empty;
    public TimeSpan Duracao { get; set; }
}

