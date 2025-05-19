using MediatR;
using Customer.Application.Interfaces;
using Customer.Domain.Entities;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerEntity>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerEntity> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new CustomerEntity
        {
            Id = 0,
            Name = request.Name,
            Email = request.Email,
            Address = request.Address,
            RegistrationDate = DateTime.UtcNow
        };

        await _customerRepository.AddAsync(customer);
        return customer;
    }
}
