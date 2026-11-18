using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}