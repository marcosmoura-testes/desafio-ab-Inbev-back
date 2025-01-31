using domain.Entity;
using infra;
using infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace employee_api_test.Unity.Infra.Repository;

public class EmployeeRepositoryTest
{
    [Test]
    public void NewEmployeeRepositorySuccess()
    {
        var baseContext = new BaseContext(new DbContextOptions<BaseContext>());
        EmployeeRepository employeeRepository = new EmployeeRepository(baseContext);
        
        Assert.NotNull(employeeRepository);
    }
}