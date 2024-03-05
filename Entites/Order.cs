using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBasic.Entites
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdersId { get; set; }

        [Required]
        public string nameEmployee { get; set; }

        [Required]
        public string Address { get; set; }

        public string DateOrder { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
