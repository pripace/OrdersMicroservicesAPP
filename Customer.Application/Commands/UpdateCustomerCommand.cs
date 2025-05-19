using Customer.Domain.Entities;
using MediatR;

public class UpdateCustomerCommand : IRequest<CustomerEntity>
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Address { get; set; } 
}
