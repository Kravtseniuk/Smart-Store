using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartStore_Models
{
    public class Product
    {
        public Product()
        {
            TempQuantity = 1;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Назва")]
        public string Name { get; set; }

        [DisplayName("Короткий опис")]
        public string ShortDesc { get; set; }

        [DisplayName("Характеристики")]
        public string Description { get; set; }

        [DisplayName("Ціна")]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        [DisplayName("Фото")]
        public string Image { get; set; }
        
        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [NotMapped]
        [Range(1,10000, ErrorMessage = "Кількість товару має бути більше 0")]
        public int TempQuantity { get; set; }
    }
}
