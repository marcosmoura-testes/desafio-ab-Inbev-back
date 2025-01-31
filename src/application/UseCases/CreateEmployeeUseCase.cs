using application.Interfaces;
using domain.DTO;
using domain.Entity;
using domain.UoW;
using domain.Utils;
using domain.ValueObjects;
using FluentValidation.Results;

namespace application.UseCases;

public class CreateEmployeeUseCase : ICreateEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string[]> Execute(EmployeeDTO employeeDTO, string accessLevelLogaded)
    {
        PasswordHasher PasswordHasher = new PasswordHasher();
        try
        {
            AccessLevelEnum accessLevelLogadedEnum = (AccessLevelEnum)Enum.Parse(typeof(AccessLevelEnum), accessLevelLogaded);
            AccessLevelEnum employeeAccessLevelEnum = (AccessLevelEnum)Enum.Parse(typeof(AccessLevelEnum), employeeDTO.AccessLevel);
                
            if(employeeAccessLevelEnum > accessLevelLogadedEnum)
                return new[] { "You are not authorized to create a new employee with a higher access level than yours."};
            
            Employee employee = new Employee(employeeDTO);
            
            var validationResult = employee.IsValid();

            if (!validationResult.isValid)
            {
                return validationResult.errorMessages;
            }

            employee.Password = PasswordHasher.HashPassword($"{employee.Email}{employee.Password}");
            _unitOfWork.EmployeesRepository.Save(employee);
            return null;
        }
        catch (Exception ex)
        {
            return new[] { "An unexpected error occurred: " + ex.Message };
        }
    }
}