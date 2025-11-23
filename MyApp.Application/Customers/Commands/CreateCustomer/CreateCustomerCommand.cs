using MediatR;

namespace MyApp.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(string Name, string Email) : IRequest<Guid>;