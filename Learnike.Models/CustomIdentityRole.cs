using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Learnike.Models
{
    public class CustomIdentityRole : IdentityRole<int>
    {
        public CustomIdentityRole() : base()
        {
        }

        public CustomIdentityRole(string roleName) : base(roleName)
        {
        }
    }
}
