using infra;
using infra.UoW;
using Microsoft.EntityFrameworkCore;

namespace employee_api_test.Unity.Infra.UoW;

public class UnitOfWorkTest
{
    [Test]
    public void InstanceUoWSuccess()
    {
        var baseContext = new BaseContext(new DbContextOptions<BaseContext>());
        var unitOfWork = new UnitOfWork(baseContext);
        
        Assert.NotNull(unitOfWork);
    }
}