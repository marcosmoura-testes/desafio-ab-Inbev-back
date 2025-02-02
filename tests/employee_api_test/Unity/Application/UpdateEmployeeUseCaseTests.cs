using application.UseCases;
using domain.DTO;
using domain.Entity;
using domain.UoW;
using Moq;

namespace employee_api_test.Unity.Application;

public class UpdateEmployeeUseCaseTests
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

        
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetById(It.IsAny<int>()))
            .Returns(employee);
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.Update(It.IsAny<Employee>()))
            .Returns(employee);

        UpdateEmployeeUseCase useCase = new(_unitOfWorkMock.Object);
       
        EmployeeDTO employeeDto = new EmployeeDTO(employee);
        var executeReturn = await useCase.Execute(employee.Id, employeeDto);

        Assert.IsNull(executeReturn);
    }

    [Test]
    public async Task UpdateEmployee_Failure()
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
        
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.GetById(It.IsAny<int>()))
            .Returns((Employee)null);
        _unitOfWorkMock.Setup(uow => uow.EmployeesRepository.Update(It.IsAny<Employee>()))
            .Returns(employee);

        UpdateEmployeeUseCase useCase = new(_unitOfWorkMock.Object);

        EmployeeDTO employeeDto = new EmployeeDTO(employee);
        var executeReturn = await useCase.Execute(employee.Id, employeeDto);

        Assert.IsNotNull(executeReturn);
        Assert.That(executeReturn[0], Is.EqualTo("Employee not found."));
    }
}