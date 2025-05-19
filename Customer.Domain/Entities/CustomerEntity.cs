namespace Customer.Domain.Entities;

public class CustomerEntity
{
    public int Id { get; set; } 

    public string Name { get; set; } 

    public string Email { get; set; } 

    public string Address { get; set; } 

    public DateTime RegistrationDate { get; set; }
}
