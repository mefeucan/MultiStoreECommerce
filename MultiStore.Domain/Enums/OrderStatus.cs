namespace MultiStore.Domain.Enums
{
    /// <summary>
    /// It shows the current status of the order and shipment.
    /// </summary>
    public enum OrderStatus
    {
        Inprogress = 1,
        Shipped = 2,
        Indistribution = 3,
        Delivered = 4,
        CancellationRefund = 5
    }
}