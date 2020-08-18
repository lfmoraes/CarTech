using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarTech.Domain.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
