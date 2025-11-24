using System;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Repositories;
using MyApp.Domain.Entities;

namespace MyApp.Application.Orders.Services;

public class OrderService : IOrderService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderService(ICustomerRepository customerRepository, IOrderRepository orderRepository)
    {
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Guid> CreateOrderAsync(Guid customerId, string details)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null) throw new KeyNotFoundException("Customer not found");

        var order = new Order(details);
        order.AttachToCustomer(customerId);

        await _orderRepository.AddAsync(order);
        return order.Id;
    }

    public async Task CancelOrderAsync(Guid orderId)
    {
        var all = await _customerRepository.GetAllAsync();
        var customer = all.FirstOrDefault(c => c.Orders.Any(o => o.Id == orderId));
        if (customer == null) throw new KeyNotFoundException("Order or Customer not found");

        var order = customer.Orders.First(o => o.Id == orderId);
        order.Cancel();
        await _customerRepository.SaveAsync(customer);
    }
}