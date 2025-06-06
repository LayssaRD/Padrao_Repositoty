using Gerenciador_Catalogo_Produtos.Menu;

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
        case 1: Menu_Gerenciador_Catalogo_Produtos.Adicionar(); break;
        case 2: Menu_Gerenciador_Catalogo_Produtos.Listar(); break;
        case 3: Menu_Gerenciador_Catalogo_Produtos.BuscarPorId(); break;
        case 4: Menu_Gerenciador_Catalogo_Produtos.Atualizar(); break;
        case 5: Menu_Gerenciador_Catalogo_Produtos.Remover(); break;
        case 0: Console.WriteLine("Saindo..."); break;
        default: Console.WriteLine("Opção inválida."); break;
    }

} while (opcao != 0);