using application.UseCases;
using domain.Entity;
using domain.UoW;
using Moq;

namespace employee_api_test.Unity.Application;

public class ConsultEmployeeUseCaseTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
    }

    [Test]
    public async Task ConsultEmployee_Sucess()
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
        

        ConsultEmployeeUseCase useCase = new(_unitOfWorkMock.Object);
       
        var executeReturn = await useCase.Execute( 1);

        Assert.IsNotNull(executeReturn);
    }

    [Test]
    public async Task ConsultEmployee_Failure()
    {
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetById(It.IsAny<int>()))
            .Throws(new Exception("fail on uow"));
        

        ConsultEmployeeUseCase useCase = new(_unitOfWorkMock.Object);
       
        var executeReturnException = Assert.ThrowsAsync<Exception>(async () =>
        {
            await useCase.Execute( 1);
        });
        
        Assert.IsNotNull(executeReturnException);
        Assert.That(executeReturnException.Message, Is.EqualTo("fail on uow"));
    }
}