using MultiStore.Domain.Entities;

namespace MultiStore.Application.Interfaces.Repositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        // In addition to the standard Add/Delete operations, a store-specific query:
        // When you bring the store, bring the items on sale inside it as well.
        Task<Store?> GetStoreWithProductsAsync(Guid storeId);
    }
}