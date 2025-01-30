using domain.Entity;

namespace application.Interfaces;

public interface ICreateEmployeeUseCase
{
    Task<string[]> Execute(Employee employee);
}