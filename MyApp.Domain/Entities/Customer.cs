namespace MyApp.Domain.Entities;

using System;
using System.Collections.Generic;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    public List<Order> Orders { get; private set; } = new();

    protected Customer() { } // para EF

    public Customer(string name, string email)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
        Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateEmail(string newEmail)
    {
        Email = !string.IsNullOrWhiteSpace(newEmail) ? newEmail : throw new ArgumentNullException(nameof(newEmail));
    }

    public void AddOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        Orders.Add(order);
    }
}