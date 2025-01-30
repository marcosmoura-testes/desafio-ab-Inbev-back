using domain.Entity;

namespace application.Interfaces;

public interface IConsultEmployeeUseCase
{
    Task<Employee> Execute(int id);
}