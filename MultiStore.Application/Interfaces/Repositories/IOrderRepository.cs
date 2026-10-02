using MultiStore.Domain.Entities;

namespace MultiStore.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        // Users should only be able to view their own orders (FR-ORDER-05).
        // To implement this rule, here is our method for retrieving user-specific orders from the database:
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
    }
}