using FluentValidation;
using Order.Application.Commands;

namespace Order.Application.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("El Id de customer no puede ser 0.");

            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Debe colocar un nombre del cliente.")
                .Length(2, 100)
                .WithMessage("El nombre debe tener entre 2 y 100 caracteres.");

            RuleFor(x => x.OrderItems)
                .NotEmpty()
                .WithMessage("La lista de productos no puede estar vacía.")
                .Must(items => items.All(item => item.Quantity > 0))
                .WithMessage("La cantidad de productos debe ser mayor a 0.")
                .Must(items => items.All(item => item.UnitPrice > 0))
                .WithMessage("El precio  de cada producto debe ser mayor a 0.");
        }
    }
}
