namespace application.Interfaces;

public interface IDeleteEmployeeUseCase
{
    Task<string[]> Execute(int employeeId);
}