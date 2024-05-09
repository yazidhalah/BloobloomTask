using Microsoft.AspNetCore.Identity;

namespace Entity.Auth
{
    public class ApplicationUser : IdentityUser<int>
    {
    }
    public class ApplicationRole : IdentityRole<int> { 
    
    }
}
