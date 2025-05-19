using Customer.Application.Interfaces;
using Customer.Domain.Entities;
using MediatR;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerEntity>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerEntity> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);
        if (customer == null)
            return null;

        customer.Name = request.Name;
        customer.Email = request.Email;
        customer.Address = request.Address;

        await _repository.UpdateAsync(customer);
        return customer;
    }
}
