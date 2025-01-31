using System.Text.Json.Serialization;
using domain.DTO;

namespace domain.Entity;

public class EmployeeContact
{
    public EmployeeContact(){}
    
    public EmployeeContact(EmployeeContactDTO dto)
    {
        if (dto == null) throw new ArgumentNullException(nameof(dto));

        Id = dto.Id;
        EmployeeId = dto.EmployeeId;
        PhoneNumber = dto.PhoneNumber;
        ContactName = dto.ContactName;
    }

    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string PhoneNumber { get; set; }
    public string ContactName { get; set; }
    
    [JsonIgnore] 
    public Employee Employee { get; set; }
}