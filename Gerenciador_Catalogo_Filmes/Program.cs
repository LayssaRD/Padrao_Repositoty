using Gerenciador_Catalogo_Filmes.Menu;

int opcao;
        do
        {
            Console.WriteLine("\n===== MENU CATÁLOGO DE FILMES =====");
            Console.WriteLine("1 - Adicionar Filme");
            Console.WriteLine("2 - Listar Filmes");
            Console.WriteLine("3 - Buscar Filme por Nome");
            Console.WriteLine("4 - Buscar Filmes por Gênero");
            Console.WriteLine("5 - Remover Filme");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.TryParse(Console.ReadLine(), out int temp) ? temp : -1;

            switch (opcao)
            {
                case 1: Menu_Catalogo_Filmes.Adicionar(); break;
                case 2: Menu_Catalogo_Filmes.Listar(); break;
                case 3: Menu_Catalogo_Filmes.BuscarPorNome(); break;
                case 4: Menu_Catalogo_Filmes.BuscarPorGenero(); break;
                case 5: Menu_Catalogo_Filmes.Remover(); break;
                case 0: Console.WriteLine("Saindo..."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

        } while (opcao != 0);
    
