using application.Interfaces;
using domain.DTO;
using domain.Entity;
using domain.UoW;

namespace application.UseCases;

public class UpdateEmployeeUseCase: IUpdateEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string[]> Execute(int employeeId, EmployeeDTO employeeDTO)
    {
        try
        {
            Employee employee = _unitOfWork.EmployeesRepository.GetById(employeeId);

            if (employee == null)
            {
                return new[] { "Employee not found." };
            }

            employee.Contacts = new List<EmployeeContact>();

            foreach (var contact in  employeeDTO.Contacts)
            {
                employee.Contacts.Add(new EmployeeContact(contact)); 
            }
            
            employee.Name = employeeDTO.Name;
            employee.Email = employeeDTO.Email;
            employee.DocumentNumber = employeeDTO.DocumentNumber;
            
            employee.Address = employeeDTO.Address;
            employee.AddressNumber = employeeDTO.AddressNumber;
            employee.City = employeeDTO.City;
            employee.State = employeeDTO.State;
            employee.Zip = employeeDTO.Zip;
            employee.ManagerName = employeeDTO.ManagerName;
            
            Employee employeeManager = _unitOfWork.EmployeesRepository.GetById(employeeDTO.ManagerId);

            if(employeeManager == null)
                return new[] { "the manager was not found." };
            
            employee.ManagerId = employeeManager.ManagerId;
            employee.ManagerName = employeeManager.Name;
            
            _unitOfWork.EmployeesRepository.Update(employee);
            return null;
        }
        catch (Exception ex)
        {
            return new[] { "An unexpected error occurred: " + ex.Message };
        }
    }
}