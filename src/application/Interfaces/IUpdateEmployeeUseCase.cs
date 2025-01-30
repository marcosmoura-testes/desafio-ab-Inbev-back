using domain.Entity;

namespace application.Interfaces;

public interface IUpdateEmployeeUseCase
{
    Task<string[]> Execute(int employeeId, Employee employeeUpdate);
}