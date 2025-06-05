using Repository.Entidade;
namespace Repository.Interfaces;

public interface IRepositorio<T> where T: class, IEntidade
{
    void Adicionar(T entidade);
}
