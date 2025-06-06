using Gerenciador_Funcionario_Departamento.Menu;

int opcao;
        do
        {
            Console.WriteLine("\n===== MENU FUNCIONÁRIOS E DEPARTAMENTOS =====");
            Console.WriteLine("1 - Adicionar Departamento");
            Console.WriteLine("2 - Listar Departamentos");
            Console.WriteLine("3 - Adicionar Funcionário");
            Console.WriteLine("4 - Listar Funcionários");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");

            opcao = int.TryParse(Console.ReadLine(), out int temp) ? temp : -1;

            switch (opcao)
            {
                case 1: Menu_Funcionario_Departamento.AdicionarDepartamento(); break;
                case 2: Menu_Funcionario_Departamento.ListarDepartamentos(); break;
                case 3: Menu_Funcionario_Departamento.AdicionarFuncionario(); break;
                case 4: Menu_Funcionario_Departamento.ListarFuncionarios(); break;
                case 0: Console.WriteLine("Voltando ao menu anterior..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        } while (opcao != 0);

