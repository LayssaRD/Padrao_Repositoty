using Repository.Implementacoes;
using Repository.Modelos;

namespace Repository.Menus;

public class Gerenciador_Catalogo_Produtos
{
    private static readonly ProdutoJsonRepository _repo = new();

    public static void Executar()
    {
        int opcao;
        do
        {
            Console.WriteLine("\n===== MENU PRODUTOS =====");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Buscar por ID");
            Console.WriteLine("4 - Atualizar Produto");
            Console.WriteLine("5 - Remover Produto");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.TryParse(Console.ReadLine(), out int temp) ? temp : -1;

            switch (opcao)
            {
                case 1: Adicionar(); break;
                case 2: Listar(); break;
                case 3: BuscarPorId(); break;
                case 4: Atualizar(); break;
                case 5: Remover(); break;
                case 0: Console.WriteLine("Saindo..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        } while (opcao != 0);
    }

    private static void Adicionar()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();

        Console.Write("Descrição: ");
        var descricao = Console.ReadLine();

        Console.Write("Preço: ");
        var preco = decimal.Parse(Console.ReadLine()!);

        Console.Write("Estoque: ");
        var estoque = int.Parse(Console.ReadLine()!);

        var produto = new Produto
        {
            Nome = nome!,
            Descricao = descricao!,
            Preco = preco,
            Estoque = estoque
        };

        _repo.Adicionar(produto);
        Console.WriteLine("Produto adicionado com sucesso.");
    }

    private static void Listar()
    {
        var produtos = _repo.ObterTodos();
        if (!produtos.Any())
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (var p in produtos)
        {
            Console.WriteLine($"ID: {p.Id} - Nome: {p.Nome} - Preço: R$ {p.Preco} - Estoque: {p.Estoque}");
        }
    }

    private static void BuscarPorId()
    {
        Console.Write("Digite o ID do produto: ");
        var id = Guid.Parse(Console.ReadLine()!);
        var produto = _repo.ObterPorId(id);

        if (produto != null)
        {
            Console.WriteLine($"{produto.Nome} - R$ {produto.Preco} - Estoque: {produto.Estoque}");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }

    private static void Atualizar()
    {
        Console.Write("ID do produto a atualizar: ");
        var id = Guid.Parse(Console.ReadLine()!);
        var produto = _repo.ObterPorId(id);

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        Console.Write("Novo nome: ");
        produto.Nome = Console.ReadLine()!;

        Console.Write("Nova descrição: ");
        produto.Descricao = Console.ReadLine()!;

        Console.Write("Novo preço: ");
        produto.Preco = decimal.Parse(Console.ReadLine()!);

        Console.Write("Novo estoque: ");
        produto.Estoque = int.Parse(Console.ReadLine()!);

        _repo.Atualizar(produto);
        Console.WriteLine("Produto atualizado com sucesso.");
    }

    private static void Remover()
    {
        Console.Write("Digite o ID do produto a remover: ");
        var id = Guid.Parse(Console.ReadLine()!);
        if (_repo.Remover(id))
            Console.WriteLine("Produto removido com sucesso.");
        else
            Console.WriteLine("Produto não encontrado.");
    }

}
