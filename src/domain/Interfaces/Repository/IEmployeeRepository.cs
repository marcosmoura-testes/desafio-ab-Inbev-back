using domain.Entity;

namespace domain.Interfaces.Repository;

public interface IEmployeeRepository: IBaseRepository<Employee, int>
{
    Task<Employee> GetByEmail(string email);
}