using MultiStore.Domain.Common;
using MultiStore.Domain.Enums;

namespace MultiStore.Domain.Entities;

/// <summary>
/// A store's package within an order. A multi-store order has one shipment
/// per store, so each package can be tracked separately.
/// </summary>
public class Shipment : BaseEntity
{
    // State machine: current status -> statuses it may move to.
    // Static so the rules are created once and shared by all shipments.
    private static readonly Dictionary<ShipmentStatus, ShipmentStatus[]> AllowedTransitions = new()
    {
        [ShipmentStatus.Preparing] = [ShipmentStatus.Shipped, ShipmentStatus.Cancelled],
        [ShipmentStatus.Shipped] = [ShipmentStatus.OutForDelivery],
        [ShipmentStatus.OutForDelivery] = [ShipmentStatus.Delivered, ShipmentStatus.Returned],
        [ShipmentStatus.Delivered] = [ShipmentStatus.Returned],
        [ShipmentStatus.Cancelled] = [], // final state
        [ShipmentStatus.Returned] = []   // final state
    };

    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!; // populated by EF Core

    public Guid StoreId { get; set; }

    public Store Store { get; set; } = null!; // populated by EF Core

    public string CarrierName { get; set; } = string.Empty; // entered by admin, no carrier API

    public string TrackingNumber { get; set; } = string.Empty; // string: may contain letters

    /// <summary>
    /// Current status. Private setter: can only be changed through
    /// <see cref="ChangeStatus"/> so invalid transitions are impossible.
    /// </summary>
    public ShipmentStatus Status { get; private set; } = ShipmentStatus.Preparing;

    public DateTime? EstimatedDeliveryDate { get; set; } // optional per spec

    /// <summary>
    /// Checks whether the shipment can move from its current status to the given one.
    /// </summary>
    /// <param name="newStatus">The requested status.</param>
    /// <returns><c>true</c> if the transition is allowed; otherwise <c>false</c>.</returns>
    public bool CanChangeStatusTo(ShipmentStatus newStatus)
    {
        return AllowedTransitions.TryGetValue(Status, out var allowedStatuses)
            && allowedStatuses.Contains(newStatus);
    }

    /// <summary>
    /// Changes the status after validating the transition.
    /// </summary>
    /// <param name="newStatus">The requested status.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the transition is not allowed, e.g. Delivered -> Preparing.
    /// </exception>
    public void ChangeStatus(ShipmentStatus newStatus)
    {
        if (!CanChangeStatusTo(newStatus))
        {
            throw new InvalidOperationException(
                $"Shipment status cannot change from {Status} to {newStatus}.");
        }

        Status = newStatus;
        UpdatedAt = DateTime.UtcNow; // lets the customer see when tracking was last updated
    }
}