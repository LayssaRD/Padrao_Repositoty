using System;
using Gerenciador_Catalogo_Produtos.Implementacoes;
using Gerenciador_Catalogo_Produtos.Model;

namespace Gerenciador_Catalogo_Produtos.Menu;

public class Menu_Gerenciador_Catalogo_Produtos
{
    private static readonly ProdutoJsonRepository _repo = new();
    
    public static void Adicionar()
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

    public static void Listar()
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

    public static void BuscarPorId()
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

    public static void Atualizar()
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

    public static void Remover()
    {
        Console.Write("Digite o ID do produto a remover: ");
        var id = Guid.Parse(Console.ReadLine()!);
        if (_repo.Remover(id))
            Console.WriteLine("Produto removido com sucesso.");
        else
            Console.WriteLine("Produto não encontrado.");
    }
}
