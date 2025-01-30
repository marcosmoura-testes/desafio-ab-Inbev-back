using domain.Entity;
using domain.UoW;

namespace application.UseCases;

public class UpdateEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string[]> Execute(int employeeId, Employee employeeUpdate)
    {
        try
        {
            Employee employee = _unitOfWork.EmployeesRepository.GetById(employeeId);

            if (employee == null)
            {
                return new[] { "Employee not found." };
            }

            employee.Name = employeeUpdate.Name;
            employee.Email = employeeUpdate.Email;
            employee.DocumentNumber = employeeUpdate.DocumentNumber;
            employee.Phone = employeeUpdate.Phone;
            employee.Address = employeeUpdate.Address;
            employee.AddressNumber = employeeUpdate.AddressNumber;
            employee.City = employeeUpdate.City;
            employee.State = employeeUpdate.State;
            employee.Zip = employeeUpdate.Zip;
            employee.ManagerName = employeeUpdate.ManagerName;
            
            _unitOfWork.EmployeesRepository.Update(employee);
            return null;
        }
        catch (Exception ex)
        {
            return new[] { "An unexpected error occurred: " + ex.Message };
        }
    }
}