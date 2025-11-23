using AutoMapper;
using MyApp.Domain.Entities;
using MyApp.Application.Customers.Queries;

namespace MyApp.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<Order, OrderDto>()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));
    }
}