using domain.Entity;
using domain.UoW;

namespace application.UseCases;

public class DeleteEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string[]> Execute(int employeeId)
    {
        try
        {
            Employee employee = _unitOfWork.EmployeesRepository.GetById(employeeId);

            if (employee == null)
            {
                return new[] { "Employee not found." };
            }
            
            _unitOfWork.EmployeesRepository.Delete(employeeId);
            return null;
        }
        catch (Exception ex)
        {
            return new[] { "An unexpected error occurred: " + ex.Message };
        }
    }
}