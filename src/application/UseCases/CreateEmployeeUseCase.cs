using domain.Entity;

namespace application.UseCases;

public class CreateEmployeeUseCase
{
    public async Task<string[]> Execute(Employee employee)
    {
        var employeeValidation = employee.IsValid();
        
        if(!employeeValidation.isValid)
            return employeeValidation.errorMessages;

        return null;
    }
}