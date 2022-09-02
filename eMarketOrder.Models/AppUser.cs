using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMarketOrder.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string UserFullName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
