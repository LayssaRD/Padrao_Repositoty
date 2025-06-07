using GenericRepository.Entidade;

namespace Plataforma_Cursos_Online.Entidades;

public class CursoOnline : IEntidade
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Instrutor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int CargaHoraria { get; set; }
    public string Nivel { get; set; } = string.Empty; // Iniciante, Intermediário, Avançado
    public DateTime DataCriacao { get; set; }
    public DateTime? DataPublicacao { get; set; }
    public bool Ativo { get; set; }
    public string? UrlImagem { get; set; }
    public List<string> Tags { get; set; } = new();
    public int MaximoAlunos { get; set; }
    public int AlunosMatriculados { get; set; }

    public bool PossuiVagas => AlunosMatriculados < MaximoAlunos;
    public bool Publicado => DataPublicacao.HasValue && Ativo;

    public override string ToString()
    {
        return $"{Titulo} - {Instrutor} | {Categoria} | {Nivel} | R$ {Preco:F2} | " +
               $"{AlunosMatriculados}/{MaximoAlunos} alunos | {(Publicado ? "Publicado" : "Não Publicado")}";
    }
} 