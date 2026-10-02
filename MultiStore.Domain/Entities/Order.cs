using MultiStore.Domain.Common;
using MultiStore.Domain.Enums;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// Represents successfully completed orders and shipping tracking.
    /// </summary>
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        /// <summary>
        /// The final order total verified by the backend.
        /// </summary>
        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Inprogress;

        /// <summary>
        /// The tracking number provided by the shipping company.
        /// </summary>
        public string? TrackingNumber { get; set; }

         /// <summary>
         /// The name of the selected shipping company.
         /// </summary>
         public string? ShippingCompany { get; set; }

         public ICollection<OrderItem> Items { get; set;} = new List<OrderItem>();
    }
}