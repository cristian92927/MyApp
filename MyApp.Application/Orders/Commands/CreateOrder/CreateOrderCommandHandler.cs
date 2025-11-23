using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using MyApp.Application.Orders.Services;

namespace MyApp.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderService _orderService;

    public CreateOrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var id = await _orderService.CreateOrderAsync(request.CustomerId, request.Details);
        return id;
    }
}