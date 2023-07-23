using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore_Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [NotMapped]
        public string StreetAddress { get; set; }
        
        [NotMapped]
        public string City { get; set; }

        [NotMapped]
        public string State { get; set; }

        [NotMapped]
        public string PostalCode { get; set; }
    }
}
