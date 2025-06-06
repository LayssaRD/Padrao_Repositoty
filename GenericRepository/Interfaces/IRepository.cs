using GenericRepository.Entidade;

namespace GenericRepository.Interfaces;

public interface IRepository<T> where T : class, IEntidade
{
    void Adicionar(T entidade);
    List<T> ObterTodos();
    T? ObterPorId(Guid id);
    bool Remover(Guid id);
}
