using MultiStore.Domain.Entities;

namespace MultiStore.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        // Complex product-specific filtering rules will be added here in the future
        // For example: Retrieve by category, sort by price, list items in stock, etc.
    }
}