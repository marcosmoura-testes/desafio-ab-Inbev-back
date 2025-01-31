using application.UseCases;
using domain.Entity;
using domain.UoW;
using Moq;

namespace employee_api_test.Unity.Application;

public class QueryEmployeeUseCaseTests
{
     private Mock<IUnitOfWork> _unitOfWorkMock;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    [Test]
    public async Task UpdateEmployee_Sucess()
    {
        Employee employee = new Employee
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            DocumentNumber = "12345678",
            Contacts = new List<EmployeeContact>
            {
                new EmployeeContact
                {
                    EmployeeId = 1,
                    PhoneNumber = "12345678901",
                    ContactName = "Nome do contato"
                }
            },
            Address = "123 Main Street",
            AddressNumber = 123,
            BirthDate = DateTime.Today.AddYears(-20),
            City = "London",
            State = "London",
            Zip = "12345",
            ManagerName = "admin",
            Password = "123456@"
        };

        List<Employee> employees = new List<Employee>();
        
        employees.Add(employee);

        
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetAllPaginated(It.IsAny<int>(), It.IsAny<int>()))
            .Returns(employees);
        

        QueryEmployeeUseCase useCase = new(_unitOfWorkMock.Object);
       
        var executeReturn = await useCase.Execute(0, 1);

        Assert.IsNotNull(executeReturn);
        Assert.That(employees.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task UpdateEmployee_Failure()
    {
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetAllPaginated(It.IsAny<int>(), It.IsAny<int>()))
            .Throws(new Exception("fail on uow"));
        

        QueryEmployeeUseCase useCase = new(_unitOfWorkMock.Object);
       
        var executeReturnException = Assert.ThrowsAsync<Exception>(async () =>
        {
            await useCase.Execute(0, 1);
        });
        
        Assert.IsNotNull(executeReturnException);
        Assert.That(executeReturnException.Message, Is.EqualTo("fail on uow"));
    }
}