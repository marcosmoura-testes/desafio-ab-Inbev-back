using application.Interfaces;
using domain.Entity;
using domain.UoW;

namespace application.UseCases;

public class ConsultEmployeeUseCase : IConsultEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public ConsultEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Employee> Execute(int employeeId)
    {
        return _unitOfWork.EmployeesRepository.GetById(employeeId);
    }
}