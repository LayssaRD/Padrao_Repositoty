using Gerenciador_de_Arquivos_e_Sistemas.Model;

namespace Gerenciador_de_Arquivos_e_Sistemas.Menu;

public class Menu_Arquivos_e_Sistemas
{
    private static readonly ArquivoDigitalJsonRepository _repo = new();

    public static void Adicionar()
    {
        Console.Write("Nome do arquivo: ");
        var nome = Console.ReadLine();

        Console.Write("Tipo do arquivo (ex: pdf, jpg): ");
        var tipo = Console.ReadLine();

        Console.Write("Tamanho em bytes: ");
        long.TryParse(Console.ReadLine(), out var tamanho);

        var arquivo = new ArquivoDigital
        {
            NomeArquivo = nome!,
            TipoArquivo = tipo!,
            TamanhoBytes = tamanho,
            DataUpload = DateTime.Now
        };

        _repo.Adicionar(arquivo);
        Console.WriteLine("Arquivo adicionado com sucesso.");
    }

    public static void Listar()
    {
        var arquivos = _repo.ObterTodos();
        if (!arquivos.Any())
        {
            Console.WriteLine("Nenhum arquivo cadastrado.");
            return;
        }

        foreach (var a in arquivos)
        {
            Console.WriteLine($"ID: {a.Id} - Nome: {a.NomeArquivo} - Tipo: {a.TipoArquivo} - Tamanho: {a.TamanhoBytes} bytes - Data: {a.DataUpload}");
        }
    }

    public static void BuscarPorId()
    {
        Console.Write("Digite o ID do arquivo: ");
        if (!Guid.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var arquivo = _repo.ObterPorId(id);
        if (arquivo != null)
        {
            Console.WriteLine($"Nome: {arquivo.NomeArquivo} - Tipo: {arquivo.TipoArquivo} - Tamanho: {arquivo.TamanhoBytes} bytes - Data: {arquivo.DataUpload}");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado.");
        }
    }

    public static void Remover()
    {
        Console.Write("Digite o ID do arquivo a remover: ");
        if (!Guid.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        if (_repo.Remover(id))
            Console.WriteLine("Arquivo removido com sucesso.");
        else
            Console.WriteLine("Arquivo não encontrado.");
    }

    public static void BuscarPorTipo()
    {
        Console.Write("Digite o tipo do arquivo para busca: ");
        var tipo = Console.ReadLine();
        var arquivos = _repo.ObterPorTipo(tipo!);
        if (!arquivos.Any())
        {
            Console.WriteLine("Nenhum arquivo encontrado para este tipo.");
            return;
        }

        foreach (var a in arquivos)
        {
            Console.WriteLine($"ID: {a.Id} - Nome: {a.NomeArquivo} - Tipo: {a.TipoArquivo} - Tamanho: {a.TamanhoBytes} bytes - Data: {a.DataUpload}");
        }
    }
}
