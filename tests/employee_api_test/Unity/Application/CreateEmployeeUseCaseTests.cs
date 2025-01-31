using application.UseCases;
using domain.Entity;
using domain.UoW;
using Moq;

namespace employee_api_test.Unity.Application;

public class CreateEmployeeUseCaseTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }
    
    [Test]
    public async Task CreateEmployee_Sucess()
    {
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.Save(It.IsAny<Employee>())).Returns(new Employee(){Id = 3});
        
        CreateEmployeeUseCase useCase  = new(_unitOfWorkMock.Object); 
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
        
        var executeReturn = await useCase.Execute(employee);
        
        Assert.IsNull(executeReturn);
        
    }
    
    [Test]
    public async Task CreateEmployee_Invalid()
    {
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.Save(It.IsAny<Employee>())).Returns(new Employee(){Id = 3});
        
        CreateEmployeeUseCase useCase  = new(_unitOfWorkMock.Object); 
        Employee employee = new Employee
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            DocumentNumber = "12345678",
            Phone = "123456789",
            Address = "123 Main Street",
            AddressNumber = 123,
            BirthDate = DateTime.Today.AddYears(-10),
            City = "London",
            State = "London",
            Zip = "12345",
            ManagerName = "admin",
            Password = "123456@"
        };
        
        var executeReturn = await useCase.Execute(employee);
        
        Assert.IsNotNull(executeReturn);
        Assert.That(executeReturn[0], Is.EqualTo("The employee must be at least 18 years old."));
    }
}