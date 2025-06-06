using System;
using Gerenciador_Catalogo_Produtos.Model;

namespace Gerenciador_Catalogo_Produtos.Interfaces;

public interface IProdutoRepository
{
    void Adicionar(Produto produto);
    Produto? ObterPorId(Guid id);
    List<Produto> ObterTodos();
    void Atualizar(Produto produto);
    bool Remover(Guid id);
}
