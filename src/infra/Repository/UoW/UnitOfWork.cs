using domain.Interfaces.Repository;
using domain.UoW;

namespace infra.Repository.UoW;

public class UnitOfWork: IUnitOfWork
{
    private BaseContext _context;
    public UnitOfWork(BaseContext context)
    {
        _context = context;
    }
    private IEmployeeRepository _employeeRepository;
    
    public IEmployeeRepository EmployeesRepository {
        get
        {
            if (_employeeRepository == null)
            {
                _employeeRepository = new EmployeeRepository(_context);
            }

            return _employeeRepository;
        }
    }
}