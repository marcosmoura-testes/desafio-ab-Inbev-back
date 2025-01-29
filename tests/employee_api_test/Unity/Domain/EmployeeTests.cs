using domain.Entity;

namespace employee_api_test.Unity.Domain;

public class EmployeeTests
{
    [Test]
    public void NewValidEmployee()
    {
        Employee employee = new Employee()
        {
            Id = 1,
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Address = "123 Main Street",
            City = "London",
            State = "CA",
            DocumentNumber = "12345678",
            BirthDate = DateTime.Now,
            ManagerName = "John Doe"
        };
        
        Assert.NotNull(employee);
        var validEmployee = employee.IsValid();
        Assert.IsTrue(validEmployee.isValid);
    }
    
    [Test]
    public void NewInValidEmployee()
    {
        Employee employee = new Employee()
        {
            Id = 1,
            Email = "john.doe@gmail.com",
            Address = "123 Main Street",
            City = "London",
            State = "CA",
            DocumentNumber = "12345678",
            BirthDate = DateTime.Now,
            ManagerName = "John Doe"
        };
        
        Assert.NotNull(employee);
        var validEmployee = employee.IsValid();
        Assert.IsFalse(validEmployee.isValid);
        Assert.That(validEmployee.errorMessages[0], Is.EqualTo("Employee Name is not empty"));

    }
}