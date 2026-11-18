using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities;

public class Store : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ContactEmail { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<StoreManager> Managers { get; set; } = new List<StoreManager>();
}