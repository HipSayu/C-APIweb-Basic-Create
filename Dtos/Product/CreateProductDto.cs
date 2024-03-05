using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebBasicPlatFrom.Dtos.Product
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(
            30,
            ErrorMessage = "Id tài san pham dài từ 3 đến 30 ký tự",
            MinimumLength = 3
        )]
        private string _productID;
        public string ProductID
        {
            get => _productID;
            set => _productID = value?.Trim();
        }
        private string _nameProduct;

        [Required]
        [StringLength(30, ErrorMessage = "Tên san pham dài từ 3 đến 30 ký tự", MinimumLength = 3)]
        public string NameProduct
        {
            set => _nameProduct = value?.Trim();
            get => _nameProduct;
        }

        [Required]
        public int NumberProduct { get; set; }

        [Required]
        public double Price { get; set; }

        public int IdCategory { get; set; }
    }
}