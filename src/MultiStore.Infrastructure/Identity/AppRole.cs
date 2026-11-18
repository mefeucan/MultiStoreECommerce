using Microsoft.AspNetCore.Identity;

namespace MultiStore.Infrastructure.Identity;

public class AppRole : IdentityRole<Guid>
{
    public AppRole()
    {
        Id = Guid.CreateVersion7();
    }
}