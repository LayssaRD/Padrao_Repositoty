using Plataforma_Cursos_Online.Entidades;
using Plataforma_Cursos_Online.Implementacoes;
using Plataforma_Cursos_Online.Interfaces;
using Plataforma_Cursos_Online.Servicos;

namespace Plataforma_Cursos_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PLATAFORMA DE CURSOS ONLINE ===");
            
            ICursoOnlineRepository repository = new CursoOnlineJsonRepository();
            CatalogoCursosService catalogoService = new CatalogoCursosService(repository);
            
            var curso1 = new CursoOnline
            {
                Titulo = "C# Fundamentals",
                Descricao = "Aprenda os fundamentos da linguagem C#",
                Instrutor = "João Silva",
                Categoria = "Programação",
                Preco = 199.90m,
                CargaHoraria = 40,
                Nivel = "Iniciante",
                MaximoAlunos = 50,
                Tags = new List<string> { "C#", "POO", ".NET" }
            };
            
            Console.WriteLine("\\n--- REGISTRANDO CURSO ---");
            catalogoService.RegistrarCurso(curso1);
            
            Console.WriteLine("\\n--- PUBLICANDO CURSO ---");
            var cursos = repository.ObterTodos();
            if (cursos.Count > 0)
            {
                catalogoService.PublicarCurso(cursos[0].Id);
            }
            
            Console.WriteLine("\\n--- CATÁLOGO PÚBLICO ---");
            var catalogoPublico = catalogoService.ObterCatalogoPublico();
            foreach (var curso in catalogoPublico)
            {
                Console.WriteLine(curso);
            }
            
            Console.WriteLine("\\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
} 