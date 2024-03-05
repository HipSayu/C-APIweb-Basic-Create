using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiBasic.Dtos.Order
{
    public class OrderDto
    {
       
        public int OrdersId { get; set; }
       
        public string nameEmployee { get; set; }
   
        public string Address { get; set; }

        public string DateOrder { get; set; }
    }
}
