using Repository.Modelos;

namespace Repository.Interfaces;

public interface IProdutoRepository
{
    void Adicionar(Produto produto);
    Produto? ObterPorId(Guid id);
    List<Produto> ObterTodos();
    void Atualizar(Produto produto);
    bool Remover(Guid id);
}
