namespace MyApp.Infrastructure.Repositories
{
    using System.Threading.Tasks;
    using MyApp.Domain.Entities;
    using MyApp.Domain.Repositories;
    using MyApp.Infrastructure.Data;

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _ctx;

        public OrderRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(Order order)
        {
            await _ctx.Orders.AddAsync(order);
            await _ctx.SaveChangesAsync();
        }
    }
}