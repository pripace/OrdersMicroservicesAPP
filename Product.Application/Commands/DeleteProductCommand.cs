using MediatR;

namespace Product.Application.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }  
    }
}

