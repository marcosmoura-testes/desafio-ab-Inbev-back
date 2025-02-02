using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace infra.Repository
{
    public class BaseRepository<T, TId> where T : class
    {
        private readonly BaseContext _context;

        public BaseRepository(BaseContext context)
        {
            _context = context;
        }

        // Método para buscar uma entidade por Id com carregamento de relações
        public T GetById(TId id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            // Adiciona Includes dinâmicos, se houver
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.SingleOrDefault(e => EF.Property<TId>(e, "Id").Equals(id)); // Substitua "Id" caso o campo ID tenha nome diferente
        }

        // Método para buscar todas as entidades com carregamento de relações
        public IList<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            // Adiciona Includes dinâmicos, se houver
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        // Método para buscar todas as entidades paginadas
        public IList<T> GetAllPaginated(int limit, int page, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            // Adiciona Includes dinâmicos, se houver
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Skip((page - 1) * limit)
                        .Take(limit)
                        .ToList();
        }

        // Método para salvar uma entidade
        public T Save(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
            return t;
        }

        // Método para atualizar uma entidade
        public T Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
            return t;
        }

        // Método para excluir uma entidade
        public T Delete(TId id)
        {
            T t = GetById(id);
            if (t != null)
            {
                _context.Entry(t).State = EntityState.Deleted;
                _context.Remove(t);
                _context.SaveChanges();
            }
            return t;
        }

        // Método para contar as entidades
        public int Count()
        {
            return _context.Set<T>().Count();
        }
    }
}
