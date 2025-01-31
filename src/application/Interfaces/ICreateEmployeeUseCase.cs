using domain.DTO;
using domain.Entity;

namespace application.Interfaces;

public interface ICreateEmployeeUseCase
{
    Task<string[]> Execute(EmployeeDTO employeeDTO, string accessLevelLogaded);
}