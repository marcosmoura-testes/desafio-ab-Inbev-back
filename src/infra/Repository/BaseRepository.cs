using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace infra.Repository;

public class BaseRepository<T, TId> where T : class
{
    private readonly BaseContext _context;
    private BaseContext context;

    public BaseRepository(BaseContext context)
    {
        _context = context;
    }

    public T GetById(TId id)
    {
        return _context.Set<T>().Find(id);
    }

    public IList<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T Save(T t)
    {
        _context.Set<T>().Add(t);
        _context.SaveChanges();
        return t;
    }

    public T Update(T t)
    {
        _context.Entry(t).State = EntityState.Modified;
        _context.SaveChanges();

        return t;
    }

    public T Delete(TId id)
    {
        T t = GetById(id);
        _context.Entry(t).State = EntityState.Deleted;
        _context.Remove(t);
        _context.SaveChanges();

        return t;
    }
}