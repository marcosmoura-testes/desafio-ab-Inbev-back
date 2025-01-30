using domain.Entity;
using domain.UoW;
using FluentValidation.Results;

namespace application.UseCases;

public class CreateEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string[]> Execute(Employee employee)
    {
        try
        {
            var validationResult = employee.IsValid();

            if (!validationResult.isValid)
            {
                return validationResult.errorMessages;
            }

            _unitOfWork.EmployeesRepository.Save(employee);
            return null;
        }
        catch (Exception ex)
        {
            return new[] { "An unexpected error occurred: " + ex.Message };
        }
    }
}