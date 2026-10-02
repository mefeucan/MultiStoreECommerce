using System.Linq.Expressions;
using MultiStore.Domain.Common;

namespace MultiStore.Application.Interfaces.Repositories
{
    /// <summary>
    /// An interface that defines the basic CRUD (Create, Read, Update, Delete) operations for all entities.
    /// </summary>
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

        // To filter using LINQ queries (e.g., items with a price greater than 100)
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}