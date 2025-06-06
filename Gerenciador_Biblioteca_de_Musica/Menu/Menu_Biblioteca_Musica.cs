using Gerenciador_Biblioteca_de_Musica.Implementacoes;
using Gerenciador_Biblioteca_de_Musica.Model;

namespace Gerenciador_Biblioteca_de_Musica.Menu;

public class Menu_Biblioteca_Musica
{
    private static readonly GenericJsonRepository<Musica> _repo = new();

    public static void Adicionar()
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

    public static void Listar()
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

    public static void BuscarPorId()
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

    public static void Remover()
    {
        Console.Write("Digite o ID da música a remover: ");
        var id = Guid.Parse(Console.ReadLine()!);
        if (_repo.Remover(id))
            Console.WriteLine("Música removida com sucesso.");
        else
            Console.WriteLine("Música não encontrada.");
    }
}
