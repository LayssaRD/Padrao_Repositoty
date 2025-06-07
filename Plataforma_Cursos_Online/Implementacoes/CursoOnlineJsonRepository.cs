using GenericRepository.Implementacoes;
using Plataforma_Cursos_Online.Entidades;
using Plataforma_Cursos_Online.Interfaces;

namespace Plataforma_Cursos_Online.Implementacoes;

public class CursoOnlineJsonRepository : GenericJsonRepository<CursoOnline>, ICursoOnlineRepository
{
    public CursoOnlineJsonRepository(string? caminhoArquivo = null) 
        : base(caminhoArquivo ?? "cursos_online.json")
    {
    }

    public List<CursoOnline> ObterPorCategoria(string categoria)
    {
        return ObterTodos()
            .Where(curso => curso.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            .OrderBy(curso => curso.Titulo)
            .ToList();
    }

    public List<CursoOnline> ObterPorInstrutor(string instrutor)
    {
        return ObterTodos()
            .Where(curso => curso.Instrutor.Equals(instrutor, StringComparison.OrdinalIgnoreCase))
            .OrderBy(curso => curso.DataCriacao)
            .ToList();
    }

    public List<CursoOnline> ObterPorNivel(string nivel)
    {
        return ObterTodos()
            .Where(curso => curso.Nivel.Equals(nivel, StringComparison.OrdinalIgnoreCase))
            .OrderBy(curso => curso.Titulo)
            .ToList();
    }

    public List<CursoOnline> ObterCursosPublicados()
    {
        return ObterTodos()
            .Where(curso => curso.Publicado)
            .OrderBy(curso => curso.DataPublicacao)
            .ToList();
    }

    public List<CursoOnline> ObterCursosComVagas()
    {
        return ObterTodos()
            .Where(curso => curso.PossuiVagas && curso.Publicado)
            .OrderBy(curso => curso.Titulo)
            .ToList();
    }

    public List<CursoOnline> ObterPorFaixaPreco(decimal precoMinimo, decimal precoMaximo)
    {
        return ObterTodos()
            .Where(curso => curso.Preco >= precoMinimo && curso.Preco <= precoMaximo)
            .OrderBy(curso => curso.Preco)
            .ToList();
    }

    public CursoOnline? ObterPorTitulo(string titulo)
    {
        return ObterTodos()
            .FirstOrDefault(curso => curso.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteCursoComTitulo(string titulo)
    {
        return ObterTodos()
            .Any(curso => curso.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
    }
} 