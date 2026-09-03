using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// Represents the stores in the system
    /// </summary>
    public class Store : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        /// <summary>
        /// Determines whether the store is open 
        /// </summary>
        public bool IsActive { get; set; } = true;

        // A store can have more than one administrator (user)
        public ICollection<AppUser> Managers { get; set; } = new List<AppUser>();
        
        // A store may have more than one product
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }

}