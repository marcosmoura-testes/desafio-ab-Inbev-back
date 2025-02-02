using domain.Entity;

namespace application.Interfaces;

public interface IQueryEmployeeUseCase
{
    Task<(List<Employee> employees, int totalRecords)> Execute(int page, int limit);
}