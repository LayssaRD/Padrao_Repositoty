using System;
using Repository.Modelos;
using Repository.Implementacoes;

namespace Repository.Menus;

public class Gerenciador_Biblioteca_de_Musica
{
    private static readonly GenericJsonRepositorio<Musica> _repo = new();

    public static void Executar()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n===== MENU MÚSICAS =====");
            Console.WriteLine("1 - Adicionar Música");
            Console.WriteLine("2 - Listar Músicas");
            Console.WriteLine("3 - Buscar por ID");
            Console.WriteLine("4 - Remover Música");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.TryParse(Console.ReadLine(), out int temp) ? temp : -1;

            switch (opcao)
            {
                case 1: Adicionar(); break;
                case 2: Listar(); break;
                case 3: BuscarPorId(); break;
                case 4: Remover(); break;
                case 0: Console.WriteLine("Saindo..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        } while (opcao != 0);
    }

    private static void Adicionar()
    {
        Console.Write("Título: ");
        var titulo = Console.ReadLine();

        Console.Write("Artista: ");
        var artista = Console.ReadLine();

        Console.Write("Álbum: ");
        var album = Console.ReadLine();

        Console.Write("Duração (minutos:segundos): ");
        var duracaoStr = Console.ReadLine();
        var duracao = TimeSpan.Parse("00:" + duracaoStr);

        var musica = new Musica
        {
            Titulo = titulo!,
            Artista = artista!,
            Album = album!,
            Duracao = duracao
        };

        _repo.Adicionar(musica);
        Console.WriteLine("Música adicionada com sucesso.");
    }

    private static void Listar()
    {
        var musicas = _repo.ObterTodos();
        if (!musicas.Any())
        {
            Console.WriteLine("Nenhuma música cadastrada.");
            return;
        }

        foreach (var m in musicas)
        {
            Console.WriteLine($"ID: {m.Id} - Título: {m.Titulo} - Artista: {m.Artista} - Albúm: {m.Album} - Duração: {m.Duracao:mm\\:ss}");
        }
    }

    private static void BuscarPorId()
    {
        Console.Write("Digite o ID da música: ");
        var id = Guid.Parse(Console.ReadLine()!);
        var musica = _repo.ObterPorId(id);

        if (musica != null)
        {
            Console.WriteLine($"{musica.Titulo} - {musica.Artista} - {musica.Album} - {musica.Duracao:mm\\:ss}");
        }
        else
        {
            Console.WriteLine("Música não encontrada.");
        }
    }

    private static void Remover()
    {
        Console.Write("Digite o ID da música a remover: ");
        var id = Guid.Parse(Console.ReadLine()!);
        if (_repo.Remover(id))
            Console.WriteLine("Música removida com sucesso.");
        else
            Console.WriteLine("Música não encontrada.");
    }
}

