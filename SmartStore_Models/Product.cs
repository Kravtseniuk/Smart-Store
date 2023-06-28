using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore_Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Назва")]
        public string Name { get; set; }

        [DisplayName("Бренд")]
        public string Brand { get; set; }

        [DisplayName("Опис")]
        public string Description { get; set; }

        [DisplayName("Ціна")]
        public double Price { get; set; }

        [ValidateNever]
        [DisplayName("Фото")]
        public string Image { get; set; }

        [DisplayName("Категорія товару")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public virtual Category Category { get; set; }

        [ValidateNever]
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

    }
}
