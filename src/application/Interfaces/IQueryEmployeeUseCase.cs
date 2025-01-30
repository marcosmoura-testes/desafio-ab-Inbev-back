using domain.Entity;

namespace application.Interfaces;

public interface IQueryEmployeeUseCase
{
    Task<List<Employee>> Execute(int page, int limit);
}