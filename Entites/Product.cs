using ApiBasic.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Entites
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProductID { get; set; }
        [Required]
        public string NameProduct { set; get; }
        [Required]
        public int NumberProduct { get; set; }
        [Required]
        public double Price { get; set; }

        public int IdCategory { get; set; }                                                                                                                                                                                                                                                                                                       
        public Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
