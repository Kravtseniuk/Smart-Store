using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartStore_Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public OrderHeader OrderHeader { get; set; }


        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public double PricePerOneQnty { get; set; }
    }
}
