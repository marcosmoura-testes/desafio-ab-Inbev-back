using domain.Entity;

namespace domain.DTO;

public class EmployeeDTO
{
    public EmployeeDTO() {
    }

    public EmployeeDTO(Employee employee)
    {
        if (employee == null) throw new ArgumentNullException(nameof(employee));
    
        Id = employee.Id;
        BirthDate = employee.BirthDate;
        Name = employee.Name;
        Email = employee.Email;
        DocumentNumber = employee.DocumentNumber;
        Address = employee.Address;
        AddressNumber = employee.AddressNumber;
        City = employee.City;
        State = employee.State;
        Zip = employee.Zip;
        ManagerName = employee.ManagerName;
        Password = employee.Password;
        AccessLevel = employee.AccessLevel;

        // Preenche os contatos
        Contacts = employee.Contacts?.Select(c => new EmployeeContactDTO
        {
            PhoneNumber = c.PhoneNumber,
            ContactName = c.ContactName
        }).ToList() ?? new List<EmployeeContactDTO>();
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
    
    public ICollection<EmployeeContactDTO> Contacts { get; set; } = new List<EmployeeContactDTO>();
}