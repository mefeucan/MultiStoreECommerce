using MultiStore.Domain.Common;
using MultiStore.Domain.Enums;

namespace MultiStore.Domain.Entities;

public class Shipment : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Guid StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public string CarrierName { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public ShipmentStatus Status { get; set; } = ShipmentStatus.Preparing;
    public DateTime? EstimatedDeliveryDate { get; set; }
}