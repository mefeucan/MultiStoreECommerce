using MultiStore.Domain.Common;

namespace MultiStore.Domain.Entities
{
    /// <summary>
    /// Represents a user registered in the system
    /// </summary>
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// A securely hashed version of the password
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// A one-time code sent as part of the two-factor authentication (2FA) process
        /// </summary>
        public string? TwoFactorCode { get; set; }

        /// <summary>
        /// Expiration date of the 2FA code
        /// </summary>
        public DateTime? TwoFactorCodeExpiry { get; set; }

        //Navigation Properties
        public Guid RoleId { get; set; }
        public AppRole Role { get; set; } = null!;
    }
}