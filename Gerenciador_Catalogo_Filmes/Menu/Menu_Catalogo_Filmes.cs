using System;
using Gerenciador_Catalogo_Filmes.Implementacoes;
namespace Gerenciador_Catalogo_Filmes.Menu;
using Gerenciador_Catalogo_Filmes.Model;
public class Menu_Catalogo_Filmes
{
    private static readonly FilmeJsonRepository _repo = new();

    public static void Adicionar()
    {
        Console.Write("Título: ");
        var titulo = Console.ReadLine();

        Console.Write("Diretor: ");
        var diretor = Console.ReadLine();

        Console.Write("Ano de Lançamento: ");
        var ano = int.Parse(Console.ReadLine()!);

        Console.Write("Gênero: ");
        var genero = Console.ReadLine();

        var filme = new Filme
        {
            Titulo = titulo!,
            Diretor = diretor!,
            AnoLancamento = ano,
            Genero = genero!
        };

        _repo.Adicionar(filme);
        Console.WriteLine("Filme adicionado com sucesso.");
    }

    public static void Listar()
    {
        var filmes = _repo.ObterTodos();
        if (!filmes.Any())
        {
            Console.WriteLine("Nenhum filme cadastrado.");
            return;
        }

        foreach (var f in filmes)
        {
            Console.WriteLine($"ID: {f.Id} - Título: {f.Titulo} - Diretor: {f.Diretor} - Ano: {f.AnoLancamento} - Gênero: {f.Genero}");
        }
    }

    public static void BuscarPorNome()
    {
        Console.Write("Digite o título do filme para buscar: ");
        var titulo = Console.ReadLine()!.Trim();

        var filmes = _repo.ObterTodos()
            .Where(f => f.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filmes.Any())
        {
            Console.WriteLine($"\nFilmes encontrados com título contendo \"{titulo}\":");
            foreach (var f in filmes)
            {
                Console.WriteLine($"ID: {f.Id} - Título: {f.Titulo} - Diretor: {f.Diretor} - Ano: {f.AnoLancamento} - Gênero: {f.Genero}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum filme encontrado com esse título.");
        }
    
    }

    public static void BuscarPorGenero()
    {
        Console.Write("Digite o gênero: ");
        var genero = Console.ReadLine();
        var filmes = _repo.ObterPorGenero(genero!);

        if (!filmes.Any())
        {
            Console.WriteLine("Nenhum filme encontrado com esse gênero.");
            return;
        }

        foreach (var f in filmes)
        {
            Console.WriteLine($"ID: {f.Id} - Título: {f.Titulo} - Diretor: {f.Diretor} - Ano: {f.AnoLancamento} - Gênero: {f.Genero}");
        }
    }

    public static void Remover()
    {
        Console.Write("Digite o título do filme a remover: ");
        var titulo = Console.ReadLine()!.Trim();

        var filmes = _repo.ObterTodos();
        var filme = filmes.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme != null)
        {
            _repo.Remover(filme.Id);
            Console.WriteLine("Filme removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Filme não encontrado com esse título.");
        }
    
    }
}