using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ProductID { get; set; }

        public string NameProduct { set; get; }

        public int NumberProduct { get; set; }

        public double Price { get; set; }
    }
}
