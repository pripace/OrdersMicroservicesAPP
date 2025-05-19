using MediatR;
using Customer.Domain.Entities;

public class CreateCustomerCommand : IRequest<CustomerEntity>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
