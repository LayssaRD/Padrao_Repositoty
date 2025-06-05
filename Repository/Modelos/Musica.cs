using Repository.Entidade;

namespace Repository.Modelos;

public class Musica : IEntidade
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Artista { get; set; } = string.Empty;
    public string Album { get; set; } = string.Empty;
    public TimeSpan Duracao { get; set; }
}
