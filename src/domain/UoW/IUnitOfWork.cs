using domain.Interfaces.Repository;

namespace domain.UoW;

public interface IUnitOfWork
{
    IEmployeeRepository EmployeesRepository { get; }
}