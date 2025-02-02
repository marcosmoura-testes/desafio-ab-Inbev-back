using System.Linq.Expressions;

namespace domain.Interfaces.Repository
{
    public interface IBaseRepository<T, TId> where T : class
    {
        T GetById(TId id, params Expression<Func<T, object>>[] includeProperties);

        IList<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IList<T> GetAllPaginated(int limit, int page, params Expression<Func<T, object>>[] includeProperties);

        T Save(T t);

        T Update(T t);

        T Delete(TId id);

        int Count();
    }
}