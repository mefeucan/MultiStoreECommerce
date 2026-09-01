using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// Represents user roles in the system
    /// </summary>
    public class AppRole : BaseEntity
    {
        /// <summary>
        /// Role Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A brief explanation of what the role is for.
        /// </summary>
        public string? Description { get; set; }

        //Navigation Property: List of users with this role
        public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }
}