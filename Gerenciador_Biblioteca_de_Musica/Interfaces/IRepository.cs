using System;
using Gerenciador_Biblioteca_de_Musica.Entidade;

namespace Gerenciador_Biblioteca_de_Musica.Interfaces;

public interface IRepository<T> where T : class, IEntidade
{
    void Adicionar(T entidade);
    List<T> ObterTodos();
    T? ObterPorId(Guid id);
    bool Remover(Guid id);
}
