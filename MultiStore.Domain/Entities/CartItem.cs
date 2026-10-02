using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// Represents the individual items and their quantities added to the cart.
    /// </summary>
    public class CartItem : BaseEntity
    {
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        /// <summary>
        /// Number of items in the cart.
        /// </summary>
        public int Quantity { get; set; }
    }
}