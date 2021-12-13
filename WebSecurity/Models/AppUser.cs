using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSecurity.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Gift> Gifts { get; set; } = new List<Gift>();

        public virtual ICollection<Gift> ShoppingList { get; set; } = new List<Gift>();
    }
}
