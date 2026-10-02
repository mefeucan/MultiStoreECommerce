using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// It stores the items in an order. It contains static data to ensure that previous orders are not affected even if prices change.
    /// </summary>
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        /// <summary>
        /// The price of the product at the time of purchase (FR-ORDER-04).
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}