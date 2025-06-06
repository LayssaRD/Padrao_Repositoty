using Gerenciador_Catalogo_Produtos.Entidade;

namespace Gerenciador_Catalogo_Produtos.Model;

public class Produto : IEntidade
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
