using Gerenciador_Registro_de_Pacientes.Menu;

int opcao;

do
{
    Console.WriteLine("===== MENU PACIENTES =====");
    Console.WriteLine("1. Adicionar paciente");
    Console.WriteLine("2. Listar todos os pacientes");
    Console.WriteLine("3. Buscar paciente por ID");
    Console.WriteLine("4. Remover paciente");
    Console.WriteLine("5. Buscar por faixa etária");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha uma opção: ");

    int.TryParse(Console.ReadLine(), out opcao);

    switch (opcao)
    {
        case 1: Menu_Registro_de_Pacientes.Adicionar(); break;
        case 2: Menu_Registro_de_Pacientes.Listar(); break;
        case 3: Menu_Registro_de_Pacientes.BuscarPorId(); break;
        case 4: Menu_Registro_de_Pacientes.Remover(); break;
        case 5: Menu_Registro_de_Pacientes.BuscarPorFaixaEtaria(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida."); break;
    }
    
} while (opcao != 0);

