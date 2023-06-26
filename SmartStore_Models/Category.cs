using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore_Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Назва")]
        public string Name { get; set; }

        [DisplayName("Порядок відображення")]
        [Range(1, 100, ErrorMessage = "Порядок відображення має бути від 1 - 100")]
        public int DisplayOrder { get; set; }
    }
}
