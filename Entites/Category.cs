using ApiWebBasicPlatFrom.Entites;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBasic.Entites
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Tên loại không quá 100 ký tự")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
