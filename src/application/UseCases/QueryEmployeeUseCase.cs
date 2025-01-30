using domain.Entity;
using domain.UoW;

namespace application.UseCases;

public class QueryEmployeeUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    public QueryEmployeeUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Employee>> Execute(int page, int limit)
    {
        return _unitOfWork.EmployeesRepository.GetAllPaginated(limit, page).ToList();
    }
}