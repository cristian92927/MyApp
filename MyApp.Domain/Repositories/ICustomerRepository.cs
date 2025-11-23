namespace MyApp.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Domain.Entities;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task SaveAsync(Customer customer);
    Task DeleteAsync(Guid id);
}