using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Controllers;
using ApiWebBasicPlatFrom.Dtos.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices,ILogger<ProductController> logger) : base(logger)
        {
            _productServices = productServices;
        }
        [HttpGet("GetAllProduct")]
        public ActionResult GetAllProduct()
        {
            try
            {
                return Ok(_productServices.GetAllProducts());
                
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductById")]
        public ActionResult GetProductById(int id) 
        {
            try
            {
                return Ok(_productServices.GetProductById(id));

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("GetProductByPriceMax")]
        public ActionResult GetProductByPriceMax()
        {
            try
            {
                return Ok(_productServices.GetProductByPricesMax());

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductByPrice")]
        public ActionResult GetProductByPriceMax(double? from, double? to)
        {
            try
            {
                return Ok(_productServices.GetProductsFromTo(from, to));
                
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductBySearch")]
        public ActionResult GetProductBySearch(string search)
        {
            try
            {
                return Ok(_productServices.GetProductsWithSearch(search));

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(CreateProductDto input)
        {
            try
            {
                _productServices.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPut("UpdateProduct")]
        public ActionResult UpdateProduct(UpdateProductDto input)
        {
            try
            {
                _productServices.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _productServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductByCategory")]
        public ActionResult GetProductByCategory (string categoryName)
        {
            try
            {
                return Ok(_productServices.GetProductByCagetogry(categoryName));
            }
            catch (Exception ex) 
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductInOrder")]
        public ActionResult GetProductInOrder(int OrderId)
        {
            try
            {
                return Ok(_productServices.GetProductInOrder(OrderId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductWithPriceMaxInOrder")]
        public ActionResult GetProductWithPriceMaxInOrder(int OrderId)
        {
            try
            {
                return Ok(_productServices.GetProductWithPriceMaxInOrder(OrderId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetProductWithCategoryInOrder")] 
        public ActionResult GetProductWithCategoryInOrder(string CatetoryName, int OrderId)
        {
            try
            {
                return Ok(_productServices.GetProductWithCategoryInOrder(CatetoryName, OrderId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        

    }
}
