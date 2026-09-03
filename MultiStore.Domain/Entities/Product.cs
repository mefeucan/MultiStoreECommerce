using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// Represents the products currently on sale at the stores
    /// </summary>
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;

        //Navigation Properties
        public Guid StoreId { get; set; }
        public Store Store { get; set; } = null!;
    }
}