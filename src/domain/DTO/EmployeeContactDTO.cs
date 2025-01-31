using domain.Entity;

namespace domain.DTO;

public class EmployeeContactDTO
{
    public EmployeeContactDTO()
    {
        
    }
    public EmployeeContactDTO(EmployeeContact contact)
    {
        if (contact == null) throw new ArgumentNullException(nameof(contact));

        Id = contact.Id;
        EmployeeId = contact.EmployeeId;
        PhoneNumber = contact.PhoneNumber;
        ContactName = contact.ContactName;
    }

    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string PhoneNumber { get; set; }
    public string ContactName { get; set; }
}