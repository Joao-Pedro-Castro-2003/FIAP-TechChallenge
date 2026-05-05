using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Cadastrar(T repository);
        void Alterar(T repository);
        void Deletar(int id);
    }
}
