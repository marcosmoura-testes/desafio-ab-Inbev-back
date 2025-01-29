namespace domain.Interfaces.Repository;

public interface IBaseRepository<T, TId> where T : class
{
    T GetById(TId id);
    IList<T> GetAll();
    T Save(T t);
    T Update(T t);
    T Delete(TId id);
}