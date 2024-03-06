using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Controllers;
using ApiWebBasicPlatFrom.Dtos.Classroom;
using ApiWebBasicPlatFrom.Dtos.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ApiControllerBase
    {
        private readonly IClassroomServices _classroomServices;

        public ClassroomController(IClassroomServices classroomServices, ILogger<ClassroomController> logger) : base(logger)
        {
            _classroomServices = classroomServices;
        }
        [HttpGet("GetAll")]
        public ActionResult GetAll(FilterDto input)
        {
            try
            {
                return Ok(_classroomServices.GetClassroom(input));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpGet("GetById")]
        public ActionResult GetById(int ClassroomId)
        {
            try
            {
                return Ok(_classroomServices.GetById(ClassroomId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPost("Create")]
        public ActionResult Create(CreateClassroomDto input)
        {
            try
            {
                _classroomServices.Create(input);
                return Ok();    
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPut("Update")]
        public ActionResult Update(UpdateClassroomDto input)
        {
            try
            {
                _classroomServices.UpdateClassroom(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
