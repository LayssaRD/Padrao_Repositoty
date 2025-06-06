using Gerenciador_Registro_de_Pacientes.Implementacoes;
using Gerenciador_Registro_de_Pacientes.Models;

namespace Gerenciador_Registro_de_Pacientes.Menu;

public class Menu_Registro_de_Pacientes
{
    private static readonly PacienteJsonRepository _repo = new("pacientes.json");

    public static void Adicionar()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine();

        Console.Write("Data de nascimento (dd/MM/yyyy): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataNascimento))
        {
            Console.WriteLine("Data inválida.");
            return;
        }

        Console.WriteLine("Contato de emergência: ");
        var contatoEmergencia = Console.ReadLine();

        var paciente = new Paciente
        {
            NomeCompleto = nome!,
            DataNascimento = dataNascimento,
            ContatoEmergencia = contatoEmergencia!
        };

        _repo.Adicionar(paciente);
        Console.WriteLine("Paciente adicionado com sucesso.");
    }

    public static void Listar()
    {
        var pacientes = _repo.ObterTodos();
        if (!pacientes.Any())
        {
            Console.WriteLine("Nenhum paciente cadastrado.");
            return;
        }

        foreach (var p in pacientes)
        {
            Console.WriteLine($"ID: {p.Id} - Nome: {p.NomeCompleto} - Data de Nascimento: {p.DataNascimento:dd/MM/yyyy} - Contato de Emergência: {p.ContatoEmergencia}");
        }
    }

    public static void BuscarPorId()
    {
        Console.Write("Digite o ID do paciente: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var paciente = _repo.ObterPorId(id);
        if (paciente != null)
        {
            Console.WriteLine($"Nome: {paciente.NomeCompleto} - Data de Nascimento: {paciente.DataNascimento:dd/MM/yyyy} - Contato de Emergência: {paciente.ContatoEmergencia}");
        }
        else
        {
            Console.WriteLine("Paciente não encontrado.");
        }
    }

    public static void Remover()
    {
        Console.Write("Digite o ID do paciente a remover: ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        if (_repo.Remover(id))
            Console.WriteLine("Paciente removido com sucesso.");
        else
            Console.WriteLine("Paciente não encontrado.");
    }

    public static void BuscarPorFaixaEtaria()
    {
        Console.Write("Idade mínima: ");
        if (!int.TryParse(Console.ReadLine(), out int idadeMinima))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.Write("Idade máxima: ");
        if (!int.TryParse(Console.ReadLine(), out int idadeMaxima))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        var pacientes = _repo.ObterPorFaixaEtaria(idadeMinima, idadeMaxima);

        if (!pacientes.Any())
        {
            Console.WriteLine("Nenhum paciente encontrado nessa faixa etária.");
            return;
        }

        foreach (var p in pacientes)
        {
            int idade = DateTime.Today.Year - p.DataNascimento.Year;
            if (p.DataNascimento > DateTime.Today.AddYears(-idade)) idade--;
            Console.WriteLine($"{p.NomeCompleto} - {idade} anos");
        }
    }
}
