using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBasic.Dtos.Category
{
    public class CategoryDto
    {
        
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }
    }
}
