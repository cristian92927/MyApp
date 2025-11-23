using MediatR;

namespace MyApp.Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDto?>;