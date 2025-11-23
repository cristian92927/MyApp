using FluentValidation;

namespace MyApp.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
    }
}