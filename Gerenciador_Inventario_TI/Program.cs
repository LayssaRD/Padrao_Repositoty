using Gerenciador_Inventario_TI.Model;
using Gerenciador_Inventario_TI.Implementacoes;
using System.Globalization;
using System.Threading;
using System;

var repositorio = new InMemoryEquipamentoTIRepository();
Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");


while (true)
{
    Console.WriteLine("\n[1] Adicionar Equipamento");
    Console.WriteLine("[2] Listar Equipamentos");
    Console.WriteLine("[3] Sair");
    Console.Write("Escolha uma opção: ");
    var opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Console.Write("Nome do Equipamento: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Tipo do Equipamento (Notebook, Monitor, etc.): ");
        string tipo = Console.ReadLine() ?? "";

        Console.Write("Número de Série: ");
        string numeroSerie = Console.ReadLine() ?? "";

        Console.Write("Data de Aquisição (dd/MM/yyyy): ");
         DateTime data;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
        {
              Console.Write("Data inválida. Digite no formato dd/MM/yyyy: ");
         }

        var equipamento = new EquipamentoTI
        {
            NomeEquipamento = nome,
            TipoEquipamento = tipo,
            NumeroSerie = numeroSerie,
            DataAquisicao = data
        };

        repositorio.Adicionar(equipamento);
        Console.WriteLine("✔ Equipamento adicionado com sucesso!");
    }
    else if (opcao == "2")
    {
        Console.WriteLine("\n=== Lista de Equipamentos ===");
        foreach (var eq in repositorio.ObterTodos())
        {
            Console.WriteLine($"ID: {eq.Id}");
            Console.WriteLine($"Nome: {eq.NomeEquipamento}");
            Console.WriteLine($"Tipo: {eq.TipoEquipamento}");
            Console.WriteLine($"Nº Série: {eq.NumeroSerie}");
            Console.WriteLine($"Data Aquisição: {eq.DataAquisicao:dd/MM/yyyy}");
            Console.WriteLine("------------------------------");
        }
    }
    else if (opcao == "3")
    {
        Console.WriteLine("Encerrando...");
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }
}