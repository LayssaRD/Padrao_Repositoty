using GenericRepository.Interfaces;
using Plataforma_Cursos_Online.Entidades;

namespace Plataforma_Cursos_Online.Interfaces;

public interface ICursoOnlineRepository : IRepository<CursoOnline>
{
    List<CursoOnline> ObterPorCategoria(string categoria);
    List<CursoOnline> ObterPorInstrutor(string instrutor);
    List<CursoOnline> ObterPorNivel(string nivel);
    List<CursoOnline> ObterCursosPublicados();
    List<CursoOnline> ObterCursosComVagas();
    List<CursoOnline> ObterPorFaixaPreco(decimal precoMinimo, decimal precoMaximo);
    CursoOnline? ObterPorTitulo(string titulo);
    bool ExisteCursoComTitulo(string titulo);
} 