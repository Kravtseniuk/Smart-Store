using Microsoft.AspNetCore.Identity;

namespace SmartStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
