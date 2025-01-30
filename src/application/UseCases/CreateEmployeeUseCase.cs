using application.Interfaces;
using domain.Entity;
using domain.UoW;
using domain.Utils;
using FluentValidation.Results;

namespace application.UseCases;

public class CreateEmployeeUseCase : ICreateEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string[]> Execute(Employee employee)
    {
        PasswordHasher PasswordHasher = new PasswordHasher();
        try
        {
            var validationResult = employee.IsValid();

            if (!validationResult.isValid)
            {
                return validationResult.errorMessages;
            }

            employee.Password = PasswordHasher.HashPassword(employee.Password);
            _unitOfWork.EmployeesRepository.Save(employee);
            return null;
        }
        catch (Exception ex)
        {
            return new[] { "An unexpected error occurred: " + ex.Message };
        }
    }
}