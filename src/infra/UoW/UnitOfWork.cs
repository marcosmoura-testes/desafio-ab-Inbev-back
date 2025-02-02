using domain.Interfaces.Repository;
using domain.UoW;
using infra.Repository;

namespace infra.UoW;

public class UnitOfWork: IUnitOfWork
{
    private BaseContext _context;
    public UnitOfWork(BaseContext context)
    {
        _context = context;
    }
    
    private IEmployeeRepository _employeeRepository;
    private IEmployeeContactRepository _employeeContactRepository;
    
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

    public IEmployeeContactRepository EmployeeContactRepository
    {
        get
        {
            if (_employeeContactRepository == null)
            {
                _employeeContactRepository = new EmployeeContactRepository(_context);
            }
            return _employeeContactRepository;
        }
    }
}