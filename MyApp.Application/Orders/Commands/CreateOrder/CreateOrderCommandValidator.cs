using FluentValidation;

namespace MyApp.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required");
        RuleFor(x => x.Details).NotEmpty().WithMessage("Details are required").MaximumLength(1000);
    }
}