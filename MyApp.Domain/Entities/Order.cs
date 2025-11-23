namespace MyApp.Domain.Entities;

using System;

public enum OrderStatus { Pending = 0, Completed = 1, Cancelled = 2 }

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Details { get; private set; } = string.Empty;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; private set; }

    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    protected Order() { } // para EF

    public Order(string details)
    {
        Details = !string.IsNullOrWhiteSpace(details) ? details : throw new ArgumentNullException(nameof(details));
        CreatedAt = DateTime.UtcNow;
    }

    public void AttachToCustomer(Guid customerId) => CustomerId = customerId;
    public void Cancel() => Status = OrderStatus.Cancelled;
    public void Complete() => Status = OrderStatus.Completed;
}