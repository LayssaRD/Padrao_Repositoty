using System;
using Gerenciador_Funcionario_Departamento.Implementacoes;
using Gerenciador_Funcionario_Departamento.Model;
namespace Gerenciador_Funcionario_Departamento.Menu;

public static class Menu_Funcionario_Departamento
{
    private static readonly GenericJsonRepository<Departamento> _repoDepto = new("departamentos.json");
    private static readonly GenericJsonRepository<Funcionario> _repoFunc = new("funcionarios.json");

    public static void AdicionarDepartamento()
    {
        Console.Write("Nome do Departamento: ");
        var nome = Console.ReadLine();
        Console.Write("Sigla: ");
        var sigla = Console.ReadLine();

        var depto = new Departamento
        {
            NomeDepartamento = nome!,
            Sigla = sigla!
        };

        _repoDepto.Adicionar(depto);
        Console.WriteLine("Departamento adicionado com sucesso.");
    }

    public static void AdicionarFuncionario()
    {
        var departamentos = _repoDepto.ObterTodos();
        if (!departamentos.Any())
        {
            Console.WriteLine("Cadastre um departamento antes.");
            return;
        }

        Console.Write("Nome Completo: ");
        var nome = Console.ReadLine();

        Console.Write("Cargo: ");
        var cargo = Console.ReadLine();

        Console.WriteLine("Departamentos disponíveis:");
        for (int i = 0; i < departamentos.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {departamentos[i].NomeDepartamento} ({departamentos[i].Sigla})");
        }

        Console.Write("Escolha o número do departamento: ");
        int escolha = int.TryParse(Console.ReadLine(), out int num) ? num : -1;
        if (escolha < 1 || escolha > departamentos.Count)
        {
            Console.WriteLine("Departamento inválido.");
            return;
        }

        var funcionario = new Funcionario
        {
            NomeCompleto = nome!,
            Cargo = cargo!,
            DepartamentoId = departamentos[escolha - 1].Id
        };

        _repoFunc.Adicionar(funcionario);
        Console.WriteLine("Funcionário adicionado com sucesso.");
    }

    public static void ListarDepartamentos()
    {
        var lista = _repoDepto.ObterTodos();
        if (!lista.Any())
        {
            Console.WriteLine("Nenhum departamento cadastrado.");
            return;
        }

        foreach (var d in lista)
        {
            Console.WriteLine($"ID: {d.Id} - Nome: {d.NomeDepartamento} - Sigla: {d.Sigla}");
        }
    }

    public static void ListarFuncionarios()
    {
        var funcionarios = _repoFunc.ObterTodos();
        var departamentos = _repoDepto.ObterTodos();

        if (!funcionarios.Any())
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        foreach (var f in funcionarios)
        {
            var depto = departamentos.FirstOrDefault(d => d.Id == f.DepartamentoId);
            string nomeDepto = depto != null ? $"{depto.NomeDepartamento} ({depto.Sigla})" : "Departamento não encontrado";
            Console.WriteLine($"ID: {f.Id} - Nome: {f.NomeCompleto} - Cargo: {f.Cargo} - Departamento: {nomeDepto}");
        }
    }
}