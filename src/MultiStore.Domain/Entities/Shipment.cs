using MultiStore.Domain.Common;
using MultiStore.Domain.Enums;

namespace MultiStore.Domain.Entities;

public class Shipment : BaseEntity
{
    private static readonly Dictionary<ShipmentStatus, ShipmentStatus[]> AllowedTransitions = new()
    {
        [ShipmentStatus.Preparing] = [ShipmentStatus.Shipped, ShipmentStatus.Cancelled],
        [ShipmentStatus.Shipped] = [ShipmentStatus.OutForDelivery],
        [ShipmentStatus.OutForDelivery] = [ShipmentStatus.Delivered, ShipmentStatus.Returned],
        [ShipmentStatus.Delivered] = [ShipmentStatus.Returned],
        [ShipmentStatus.Cancelled] = [],
        [ShipmentStatus.Returned] = []
    };

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Guid StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public string CarrierName { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public ShipmentStatus Status { get; private set; } = ShipmentStatus.Preparing;
    public DateTime? EstimatedDeliveryDate { get; set; }

    public bool CanChangeStatusTo(ShipmentStatus newStatus)
    {
        return AllowedTransitions.TryGetValue(Status, out var allowedStatuses)
            && allowedStatuses.Contains(newStatus);
    }

    public void ChangeStatus(ShipmentStatus newStatus)
    {
        if (!CanChangeStatusTo(newStatus))
        {
            throw new InvalidOperationException(
                $"Shipment status cannot change from {Status} to {newStatus}."
            );
        }

        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
    }

}