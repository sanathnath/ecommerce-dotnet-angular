using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser 
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        // public string Address { get; set; }
        // public List<AppProduct> WishList { get; set; }
        // public List<AppProduct> Cart { get; set; }
        // public List<Order> Orders { get; set; }
        // public ICollection<AppUserRole> UserRoles { get; set; }
    }
}