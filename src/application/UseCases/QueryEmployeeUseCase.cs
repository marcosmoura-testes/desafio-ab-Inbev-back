using application.Interfaces;
using domain.Entity;
using domain.UoW;

namespace application.UseCases;

public class QueryEmployeeUseCase: IQueryEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public QueryEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<(List<Employee> employees, int totalRecords)> Execute(int page, int limit)
    {
        List<Employee> employees = _unitOfWork.EmployeesRepository.GetAllPaginated(limit, page, p => p.Contacts).ToList();
        int totalRecords = _unitOfWork.EmployeesRepository.Count();
        
        return (employees, totalRecords);
    }
}