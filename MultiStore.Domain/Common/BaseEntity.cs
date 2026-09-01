namespace MultiStore.Domain.Common
{
    /// <summary>
    /// This is an abstract class that contains the basic properties for all entities in the system.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The unique identity of an entity.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The date the asset was registered in the system.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// The date of the last update to the asset.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// A flag for the logical delete (soft delete) operation.
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}