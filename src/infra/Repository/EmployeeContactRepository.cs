using System.Linq.Expressions;
using domain.Entity;
using domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace infra.Repository;

public class EmployeeContactRepository: BaseRepository<EmployeeContact, int>, IEmployeeContactRepository
{
    private BaseContext _context;

    public EmployeeContactRepository(BaseContext context) : base(context)
    {
        _context = context;
    }

    public List<EmployeeContact> GetByEmployeeId(int employeeId, params Expression<Func<EmployeeContact, object>>[] includeProperties)
    {
        var query = _context.EmployeeContact.AsQueryable();

        // Incluir propriedades relacionadas dinamicamente
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return query.Where(empc => empc.EmployeeId == employeeId).ToList();
    }
}