using domain.DTO;
using FluentValidation;
    
namespace domain.Entity;

public class Employee
{
    public Employee(){}
    public Employee(EmployeeDTO dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));

        Id = dto.Id;
        BirthDate = dto.BirthDate;
        Name = dto.Name;
        Email = dto.Email;
        DocumentNumber = dto.DocumentNumber;
        Address = dto.Address;
        AddressNumber = dto.AddressNumber;
        City = dto.City;
        State = dto.State;
        Zip = dto.Zip;
        ManagerName = dto.ManagerName;
        Password = dto.Password;
        AccessLevel = dto.AccessLevel;

        // Popula a lista de contatos a partir do DTO
        Contacts = dto.Contacts?.Select(c => new EmployeeContact
        {
            Id = c.Id,
            EmployeeId = c.EmployeeId,
            PhoneNumber = c.PhoneNumber,
            ContactName = c.ContactName
        }).ToList() ?? new List<EmployeeContact>();
    }

    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? DocumentNumber { get; set; }
    public string? Address { get; set; }
    public int AddressNumber { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? ManagerName { get; set; }
    public string Password { get; set; }
    public string AccessLevel { get; set; }
    
    public ICollection<EmployeeContact> Contacts { get; set; } = new List<EmployeeContact>();


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
        RuleFor(p => p.BirthDate)
            .Must(SerMaiorDe18Anos)
            .WithMessage("The employee must be at least 18 years old.");
    }
    
    private bool SerMaiorDe18Anos(DateTime dataNascimento)
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - dataNascimento.Year;

        if (dataNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }

        return idade >= 18;
    }
}