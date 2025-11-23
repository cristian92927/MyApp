using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Repositories;
using MyApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _ctx;

    public CustomerRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<Customer>> GetAllAsync()
        => await _ctx.Customers.Include(c => c.Orders).AsNoTracking().ToListAsync();

    public async Task<Customer?> GetByIdAsync(Guid id)
        => await _ctx.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);

    public async Task SaveAsync(Customer customer)
    {
        var exists = await _ctx.Customers.AnyAsync(c => c.Id == customer.Id);
        if (exists) _ctx.Customers.Update(customer);
        else await _ctx.Customers.AddAsync(customer);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _ctx.Customers.FindAsync(id);
        if (entity != null)
        {
            _ctx.Customers.Remove(entity);
            await _ctx.SaveChangesAsync();
        }
    }
}