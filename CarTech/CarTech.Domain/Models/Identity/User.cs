using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTech.Domain.Models.Identity
{
    public class User : IdentityUser
    {
        [NotMapped]
        public string Role { get; set; }
    }
}   
