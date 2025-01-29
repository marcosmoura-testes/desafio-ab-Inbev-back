using FluentValidation;
    
namespace domain.Entity;

public class Employee
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public int AddressNumber { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? ManagerName { get; set; }

    public (bool isValid, string[] errorMessages) IsValid()
    {
        var validator = new EmployeeValidation();
        
        var result = validator.Validate(this);
        
        return (result.IsValid, result.Errors.Select(x => x.ErrorMessage).ToArray());
    }
}

public class EmployeeValidation : AbstractValidator<Employee>
{
    public EmployeeValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Employee Name is not empty");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Employee E-mail is not empty");
        RuleFor(x => x.DocumentNumber).NotEmpty().WithMessage("Employee Document Number is not empty");
    }
}