using Gerenciador_de_Arquivos_e_Sistemas.Menu;

int opcao;

do
{
    Console.WriteLine("===== MENU ARQUIVOS DIGITAIS =====");
    Console.WriteLine("1. Adicionar arquivo");
    Console.WriteLine("2. Listar arquivos");
    Console.WriteLine("3. Buscar arquivo por ID");
    Console.WriteLine("4. Remover arquivo");
    Console.WriteLine("5. Buscar arquivos por tipo");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha uma opção: ");

    int.TryParse(Console.ReadLine(), out opcao);

    switch (opcao)
    {
        case 1: Menu_Arquivos_e_Sistemas.Adicionar(); break;
        case 2: Menu_Arquivos_e_Sistemas.Listar(); break;
        case 3: Menu_Arquivos_e_Sistemas.BuscarPorId(); break;
        case 4: Menu_Arquivos_e_Sistemas.Remover(); break;
        case 5: Menu_Arquivos_e_Sistemas.BuscarPorTipo(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida."); break;
    }

} while (opcao != 0);
