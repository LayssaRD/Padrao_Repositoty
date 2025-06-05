using Repository.Interfaces;
using Repository.Modelos;
using System.Text.Json;

namespace Repository.Implementacoes;

public class ProdutoJsonRepository : IProdutoRepository
{
    private readonly string _caminhoArquivo = "produtos.json";
    private List<Produto> _produtos;

    public ProdutoJsonRepository()
    {
        _produtos = CarregarDoArquivo();
    }

    public void Adicionar(Produto produto)
    {
        if (produto.Id == Guid.Empty)
            produto.Id = Guid.NewGuid();

        _produtos.Add(produto);
        SalvarNoArquivo();
    }

    public Produto? ObterPorId(Guid id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public List<Produto> ObterTodos()
    {
        return _produtos;
    }

    public void Atualizar(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index >= 0)
        {
            _produtos[index] = produto;
            SalvarNoArquivo();
        }
    }

    public bool Remover(Guid id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            _produtos.Remove(produto);
            SalvarNoArquivo();
            return true;
        }
        return false;
    }

    private void SalvarNoArquivo()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_produtos, options);
            File.WriteAllText(_caminhoArquivo, json);
            Console.WriteLine($"Arquivo salvo em: {Path.GetFullPath(_caminhoArquivo)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar produtos: {ex.Message}");
        }
    }

    private List<Produto> CarregarDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo)) return new List<Produto>();

        try
        {
            string json = File.ReadAllText(_caminhoArquivo);
            return string.IsNullOrWhiteSpace(json)
                ? new List<Produto>()
                : JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao carregar produtos: {ex.Message}");
            return new List<Produto>();
        }
    }
}
