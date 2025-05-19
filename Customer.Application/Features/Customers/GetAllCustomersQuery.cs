using Customer.Domain.Entities;
using Customer.Application.Interfaces;
using MediatR;

namespace Customer.Application.Features.Customers;

public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerEntity>>;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerEntity>>
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerEntity>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
