using Plataforma_Cursos_Online.Entidades;
using Plataforma_Cursos_Online.Interfaces;

namespace Plataforma_Cursos_Online.Servicos;

public class CatalogoCursosService
{
    private readonly ICursoOnlineRepository _repository;

    public CatalogoCursosService(ICursoOnlineRepository repository)
    {
        _repository = repository;
    }

    public bool RegistrarCurso(CursoOnline curso)
    {
        // Validações de negócio
        if (string.IsNullOrWhiteSpace(curso.Titulo))
        {
            Console.WriteLine("Erro: Título do curso é obrigatório.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(curso.Instrutor))
        {
            Console.WriteLine("Erro: Instrutor é obrigatório.");
            return false;
        }

        // Verificar duplicatas
        if (_repository.ExisteCursoComTitulo(curso.Titulo))
        {
            Console.WriteLine($"Erro: Já existe um curso com o título '{curso.Titulo}'.");
            return false;
        }

        // Validar preço
        if (curso.Preco < 0)
        {
            Console.WriteLine("Erro: Preço não pode ser negativo.");
            return false;
        }

        // Validar carga horária
        if (curso.CargaHoraria <= 0)
        {
            Console.WriteLine("Erro: Carga horária deve ser maior que zero.");
            return false;
        }

        // Validar máximo de alunos
        if (curso.MaximoAlunos <= 0)
        {
            Console.WriteLine("Erro: Máximo de alunos deve ser maior que zero.");
            return false;
        }

        // Definir data de criação se não foi informada
        if (curso.DataCriacao == DateTime.MinValue)
        {
            curso.DataCriacao = DateTime.Now;
        }

        // Registrar o curso
        _repository.Adicionar(curso);
        Console.WriteLine($"Curso '{curso.Titulo}' registrado com sucesso!");
        return true;
    }

    public bool PublicarCurso(Guid cursoId)
    {
        var curso = _repository.ObterPorId(cursoId);
        if (curso == null)
        {
            Console.WriteLine("Erro: Curso não encontrado.");
            return false;
        }

        if (curso.Publicado)
        {
            Console.WriteLine("Erro: Curso já está publicado.");
            return false;
        }

        // Validações para publicação
        if (string.IsNullOrWhiteSpace(curso.Descricao))
        {
            Console.WriteLine("Erro: Descrição é obrigatória para publicar o curso.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(curso.Categoria))
        {
            Console.WriteLine("Erro: Categoria é obrigatória para publicar o curso.");
            return false;
        }

        curso.DataPublicacao = DateTime.Now;
        curso.Ativo = true;
        
        // Como o repository não tem método de atualização, removemos e adicionamos novamente
        _repository.Remover(cursoId);
        _repository.Adicionar(curso);
        
        Console.WriteLine($"Curso '{curso.Titulo}' publicado com sucesso!");
        return true;
    }

    public List<CursoOnline> ObterCatalogoPublico()
    {
        return _repository.ObterCursosPublicados();
    }

    public List<CursoOnline> PesquisarCursos(string termo)
    {
        return _repository.ObterTodos()
            .Where(curso => curso.Publicado && 
                           (curso.Titulo.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                            curso.Descricao.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                            curso.Tags.Any(tag => tag.Contains(termo, StringComparison.OrdinalIgnoreCase))))
            .OrderBy(curso => curso.Titulo)
            .ToList();
    }

    public bool MatricularAluno(Guid cursoId)
    {
        var curso = _repository.ObterPorId(cursoId);
        if (curso == null)
        {
            Console.WriteLine("Erro: Curso não encontrado.");
            return false;
        }

        if (!curso.Publicado)
        {
            Console.WriteLine("Erro: Curso não está publicado.");
            return false;
        }

        if (!curso.PossuiVagas)
        {
            Console.WriteLine("Erro: Curso não possui vagas disponíveis.");
            return false;
        }

        curso.AlunosMatriculados++;
        
        // Atualizar o curso
        _repository.Remover(cursoId);
        _repository.Adicionar(curso);
        
        Console.WriteLine($"Matrícula realizada com sucesso no curso '{curso.Titulo}'!");
        Console.WriteLine($"Vagas restantes: {curso.MaximoAlunos - curso.AlunosMatriculados}");
        return true;
    }

    public decimal CalcularReceitaTotal()
    {
        return _repository.ObterTodos()
            .Where(curso => curso.Publicado)
            .Sum(curso => curso.Preco * curso.AlunosMatriculados);
    }

    public Dictionary<string, int> ObterEstatisticasPorCategoria()
    {
        return _repository.ObterCursosPublicados()
            .GroupBy(curso => curso.Categoria)
            .ToDictionary(grupo => grupo.Key, grupo => grupo.Count());
    }
} 