using domain.DTO;
using domain.Entity;

namespace application.Interfaces;

public interface IUpdateEmployeeUseCase
{
    Task<string[]> Execute(int employeeId, EmployeeDTO employeeDTO);
}