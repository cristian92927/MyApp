namespace MyApp.Domain.Repositories
{
    using System.Threading.Tasks;
    using MyApp.Domain.Entities;

    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}