namespace MyApp.Application.Orders.Services;

using System;
using System.Threading.Tasks;

public interface IOrderService
{
    Task<Guid> CreateOrderAsync(Guid customerId, string details);
    Task CancelOrderAsync(Guid orderId);
}