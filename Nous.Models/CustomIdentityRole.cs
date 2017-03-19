using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nous.Models
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
