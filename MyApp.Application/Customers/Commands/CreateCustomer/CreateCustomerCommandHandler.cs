using MediatR;
using MyApp.Domain.Repositories;
using MyApp.Domain.Entities;


namespace MyApp.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly ICustomerRepository _repo;

    public CreateCustomerCommandHandler(ICustomerRepository repo) => _repo = repo;

    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Name, request.Email);
        await _repo.SaveAsync(customer);
        return customer.Id;
    }
}