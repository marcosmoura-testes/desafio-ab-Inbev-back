namespace application.Interfaces;

public interface IAuthEmployeeUseCase
{
    Task<(string token, string message)> Execute(string email, string password);
}