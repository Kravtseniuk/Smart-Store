using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartStore_Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [NotMapped]
        [DisplayName("Адреса")]
        public string StreetAddress { get; set; }

        [NotMapped]
        [DisplayName("Місто")]
        public string City { get; set; }

        [NotMapped]
        [DisplayName("Область")]
        public string State { get; set; }

        [NotMapped]
        [DisplayName("Поштовий індекс")]
        public string PostalCode { get; set; }
    }
}
