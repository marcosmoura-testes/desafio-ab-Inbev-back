using domain.Entity;
using domain.Interfaces.Repository;

namespace infra.Repository;

public class EmployeeRepository : BaseRepository<Employee, int>, IEmployeeRepository
{
    private BaseContext _context;

    public EmployeeRepository(BaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Employee> GetByEmail(string email)
    {
        return _context.Employee.FirstOrDefault(emp => emp.Email == email);
    }
}