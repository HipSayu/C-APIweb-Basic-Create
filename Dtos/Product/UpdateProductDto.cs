using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Product
{
    public class UpdateProductDto : CreateProductDto
    {
        public int Id {get; set;}
    }
}