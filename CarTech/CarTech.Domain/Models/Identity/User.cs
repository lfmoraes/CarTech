using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarTech.Domain.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}   
