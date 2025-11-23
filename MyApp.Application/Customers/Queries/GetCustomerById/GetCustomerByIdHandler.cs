using MediatR;
using MyApp.Domain.Repositories;
using AutoMapper;

namespace MyApp.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    private readonly ICustomerRepository _repo;
    private readonly IMapper _mapper;

    public GetCustomerByIdHandler(ICustomerRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repo.GetByIdAsync(request.Id);
        if (customer == null) return null;
        return _mapper.Map<CustomerDto>(customer);
    }
}