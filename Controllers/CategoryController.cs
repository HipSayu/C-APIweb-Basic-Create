using ApiBasic.Dtos.Category;
using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Controllers;
using ApiWebBasicPlatFrom.Dtos.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CategoryController : ApiControllerBase
    {
        private ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices, ILogger<CategoryController> logger) : base(logger)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet("GetAllCategory")]
        public ActionResult GetAllCategory(FilterDto input)
        {
            try
            {
               return Ok( _categoryServices.GetAll(input));
            }
            catch (Exception ex) 
            {
                return HandleException(ex);
            }
        }
        [HttpPost("Create")]
        public ActionResult Create(CreateCategoryDto input) 
        {
            try
            {
                _categoryServices.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPut("UpdateCategory")]
        public ActionResult Update(UpdateCategoryDto input)
        {
            try
            {
                _categoryServices.Update(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryServices.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
