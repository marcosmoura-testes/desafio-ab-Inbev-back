using System.Linq.Expressions;
using domain.Entity;

namespace domain.Interfaces.Repository;

public interface IEmployeeContactRepository: IBaseRepository<EmployeeContact, int>
{
    List<EmployeeContact> GetByEmployeeId(int employeeId,
        params Expression<Func<EmployeeContact, object>>[] includeProperties);
}