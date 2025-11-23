using MediatR;
using System;

namespace MyApp.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid CustomerId, string Details) : IRequest<Guid>;