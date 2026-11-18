using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities;

public class StoreManager : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; } = null!;
}