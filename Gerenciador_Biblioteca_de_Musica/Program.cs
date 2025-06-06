using Gerenciador_Biblioteca_de_Musica.Menu;

int opcao;
do
{
    Console.WriteLine("\n===== MENU MÚSICAS =====");
    Console.WriteLine("1 - Adicionar Música");
    Console.WriteLine("2 - Listar Músicas");
    Console.WriteLine("3 - Buscar por ID");
    Console.WriteLine("4 - Remover Música");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    opcao = int.TryParse(Console.ReadLine(), out int temp) ? temp : -1;

    switch (opcao)
    {
        case 1: Menu_Biblioteca_Musica.Adicionar(); break;
        case 2: Menu_Biblioteca_Musica.Listar(); break;
        case 3: Menu_Biblioteca_Musica.BuscarPorId(); break;
        case 4: Menu_Biblioteca_Musica.Remover(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida."); break;
    }

} while (opcao != 0);
