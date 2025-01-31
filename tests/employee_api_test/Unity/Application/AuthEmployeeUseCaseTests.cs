using application.UseCases;
using domain.Entity;
using domain.UoW;
using domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Moq;

namespace employee_api_test.Unity.Application;

public class AuthEmployeeUseCaseTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IConfiguration> _configurationMock;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _configurationMock = new Mock<IConfiguration>();
    }

    [Test]
    public async Task AuthEmployee_Sucess()
    {
        Employee employee = new Employee
        {
            Name = "Marcos Feitosa moura",
            Email = "marcosfeitosamoura@gmail.com",
            DocumentNumber = "12312312312",
            Contacts = new List<EmployeeContact>
            {
                new EmployeeContact
                {
                    EmployeeId = 1,
                    PhoneNumber = "12345678901",
                    ContactName = "Nome do contato"
                }
            },
            Address = "Rua exemplo teste",
            AddressNumber = 123,
            BirthDate = DateTime.Today.AddYears(-20),
            City = "São Bernado do Campo",
            State = "São Paulo",
            Zip = "09820152",
            ManagerName = "ADmin",
            AccessLevel = AccessLevelEnum.Employee.ToString(),
            Password =
                "uQJsRmTqkqFHkE2NAPEP9X3YC8lpGjEWDYsBjKot7BdDItwhw0mQgu1YUQuqwT0laMTh22O1aRbWEd9qv1ebTDQeEpiOMh3ygz+uF2QveKyk0KMtRkiFIhr31P46z9pP"
        };

        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetByEmail(It.IsAny<string>()))
            .Returns(Task.FromResult(employee));

        _configurationMock.Setup(config => config["JWT:Secret"]).Returns("20170cd157dca312cedc45bd8b7b0bf7");
        _configurationMock.Setup(config => config["JWT:ExpiresInMinutes"]).Returns("120");

        AuthEmployeeUseCase useCase = new(_unitOfWorkMock.Object, _configurationMock.Object);

        var executeReturn = await useCase.Execute("marcosfeitosamoura@gmail.com", "123456@");

        Assert.IsNotNull(executeReturn);
    }

    [Test]
    public async Task AuthEmployee_IncorretPassword()
    {
        Employee employee = new Employee
        {
            Name = "Marcos Feitosa moura",
            Email = "marcosfeitosamoura@gmail.com",
            DocumentNumber = "12312312312",
            Contacts = new List<EmployeeContact>
            {
                new EmployeeContact
                {
                    EmployeeId = 1,
                    PhoneNumber = "12345678901",
                    ContactName = "Nome do contato"
                }
            },
            Address = "Rua exemplo teste",
            AddressNumber = 123,
            BirthDate = DateTime.Today.AddYears(-20),
            City = "São Bernado do Campo",
            State = "São Paulo",
            Zip = "09820152",
            ManagerName = "ADmin",
            AccessLevel = AccessLevelEnum.Employee.ToString(),
            Password =
                "uQJsRmTqkqFHkE2NAPEP9X3YC8lpGjEWDYsBjKot7BdDItwhw0mQgu1YUQuqwT0laMTh22O1aRbWEd9qv1ebTDQeEpiOMh3ygz+uF2QveKyk0KMtRkiFIhr31P46z9p0"
        };

        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetByEmail(It.IsAny<string>()))
            .Returns(Task.FromResult(employee));

        AuthEmployeeUseCase useCase = new(_unitOfWorkMock.Object, _configurationMock.Object);

        var executeReturn = await useCase.Execute("marcosfeitosamoura@gmail.com", "123456@");

        Assert.IsNotEmpty(executeReturn.message);
        Assert.That(executeReturn.message, Is.EqualTo("incorrect Email or password"));
    }

    [Test]
    public async Task AuthEmployee_NotFound()
    {
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetByEmail(It.IsAny<string>()))
            .Returns(Task.FromResult<Employee?>(null));

        AuthEmployeeUseCase useCase = new(_unitOfWorkMock.Object, _configurationMock.Object);

        var executeReturn = await useCase.Execute("marcosfeitosamoura@gmail.com", "123456@");

        Assert.IsNotEmpty(executeReturn.message);
        Assert.That(executeReturn.message, Is.EqualTo("incorrect Email or password"));
    }
}