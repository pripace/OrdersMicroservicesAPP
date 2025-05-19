using Customer.Domain.Entities;
using Customer.Application.Interfaces;
using MediatR;

namespace Customer.Application.Features.Customers;

public record GetCustomerByIdQuery(int Id) : IRequest<CustomerEntity?>;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerEntity?>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerByIdQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerEntity?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
