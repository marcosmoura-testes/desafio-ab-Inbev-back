using application.UseCases;
using domain.Entity;
using domain.UoW;
using Moq;

namespace employee_api_test.Unity.Application;

public class DeleteEmployeeUseCaseTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    [Test]
    public async Task DeleteEmployee_Sucess()
    {
        Employee employee = new Employee
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            DocumentNumber = "12345678",
            Phone = "123456789",
            Address = "123 Main Street",
            AddressNumber = 123,
            BirthDate = DateTime.Today.AddYears(-20),
            City = "London",
            State = "London",
            Zip = "12345",
            ManagerName = "admin",
            Password = "123456@"
        };


        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetById(It.IsAny<int>()))
            .Returns(employee);
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.Delete(It.IsAny<int>()))
            .Returns(employee);

        DeleteEmployeeUseCase useCase = new(_unitOfWorkMock.Object);

        var executeReturn = await useCase.Execute(employee.Id);

        Assert.IsNull(executeReturn);
    }

    [Test]
    public async Task DeleteEmployee_Failure()
    {
        Employee employee = new Employee
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            DocumentNumber = "12345678",
            Phone = "123456789",
            Address = "123 Main Street",
            AddressNumber = 123,
            BirthDate = DateTime.Today.AddYears(-20),
            City = "London",
            State = "London",
            Zip = "12345",
            ManagerName = "admin",
            Password = "123456@"
        };

        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetById(It.IsAny<int>()))
            .Returns((Employee)null);
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.Delete(It.IsAny<int>()))
            .Returns(employee);

        DeleteEmployeeUseCase useCase = new(_unitOfWorkMock.Object);

        var executeReturn = await useCase.Execute(employee.Id);

        Assert.IsNotNull(executeReturn);
        Assert.That(executeReturn[0], Is.EqualTo("Employee not found."));
    }
}