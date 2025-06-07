using Gerenciador_de_Arquivos_Digitais.Entidades;
using Gerenciador_de_Arquivos_Digitais.Implementacoes;
using Gerenciador_de_Arquivos_Digitais.Interfaces;

namespace Gerenciador_de_Arquivos_Digitais;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== GERENCIADOR DE ARQUIVOS DIGITAIS ===");
        
        IArquivoDigitalRepository repository = new ArquivoDigitalJsonRepository();
        
        // Adicionando arquivos de exemplo
        var arquivo1 = new ArquivoDigital
        {
            NomeArquivo = "documento.pdf",
            TipoArquivo = "PDF",
            TamanhoBytes = 1024000,
            DataUpload = DateTime.Now.AddDays(-10)
        };
        
        var arquivo2 = new ArquivoDigital
        {
            NomeArquivo = "planilha.xlsx",
            TipoArquivo = "Excel",
            TamanhoBytes = 512000,
            DataUpload = DateTime.Now.AddDays(-5)
        };
        
        var arquivo3 = new ArquivoDigital
        {
            NomeArquivo = "relatorio.pdf",
            TipoArquivo = "PDF",
            TamanhoBytes = 2048000,
            DataUpload = DateTime.Now.AddDays(-2)
        };
        
        repository.Adicionar(arquivo1);
        repository.Adicionar(arquivo2);
        repository.Adicionar(arquivo3);
        
        // Demonstrando funcionalidades
        Console.WriteLine("\n--- TODOS OS ARQUIVOS ---");
        foreach (var arquivo in repository.ObterTodos())
        {
            Console.WriteLine(arquivo);
        }
        
        Console.WriteLine("\n--- ARQUIVOS PDF ---");
        foreach (var arquivo in repository.ObterPorTipoArquivo("PDF"))
        {
            Console.WriteLine(arquivo);
        }
        
        Console.WriteLine("\n--- ARQUIVOS DOS ÚLTIMOS 7 DIAS ---");
        var arquivosRecentes = repository.ObterPorPeriodo(DateTime.Now.AddDays(-7), DateTime.Now);
        foreach (var arquivo in arquivosRecentes)
        {
            Console.WriteLine(arquivo);
        }
        
        Console.WriteLine($"\n--- TAMANHO TOTAL: {repository.ObterTamanhoTotalArquivos():N0} bytes ---");
        
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
} 