using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Dtos.Shared;
using ApiWebBasicPlatFrom.Dtos.Students;
using ApiWebBasicPlatFrom.services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebBasicPlatFrom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ApiControllerBase
    {
        private IStudentServices _studentServices;
        public StudentController (IStudentServices studentServices, ILogger<StudentController> logger):base(logger)
        {
            _studentServices = studentServices ;
        }
        
        
        [HttpGet("GetStudent")]
        public ActionResult GetStudent (FilterDto input)  {
                try {
                    return Ok(_studentServices.GetStudent(input));
                }
                catch (Exception ex){
                    return HandleException(ex);
                }
        }
        [AllowAnonymous]
        [HttpGet("GetStudentById")]
        public ActionResult GetStudentById (int StudentId) {
             try {
                    return Ok(_studentServices.GetById(StudentId));
                }
             catch (Exception ex){
                    return HandleException(ex);
                }
        }
        [HttpPost("CreateStudent")]
        public ActionResult CreateStudent (CreateStudentDto input) {
             try {
                    _studentServices.Create(input);
                    return Ok();
                }
                catch (Exception ex){
                    return HandleException(ex);
                }
        }
        [HttpPut("UpdateStudent")]
        public ActionResult UpdateStudent (UpdateStudentDto input) {
             try {
                    _studentServices.UpdateStudent(input);
                    return Ok();
                }
                catch (Exception ex){
                    return HandleException(ex);
                }
        }
        [HttpDelete("StudentDelete")]
         public ActionResult StudentDelete (int StudentId) {
             try {
                    _studentServices.DeleteStudentById(StudentId);
                    return Ok();
                }
                catch (Exception ex){
                    return HandleException(ex);
                }
        }
        [HttpGet("GetStudentInClassroom")]
        public ActionResult GetStudentInClassroom (int ClassroomId)  {
                try {
                    return Ok(_studentServices.GetStudentInClassroom(ClassroomId));
                }
                catch (Exception ex){
                    return HandleException(ex);
                }
        }
        [HttpGet("GetStudentWithMaxAgeInClassroom")]
        public ActionResult GetStudentWithMaxAgeInClassroom(int ClassroomId)
        {
            try
            {
                return Ok(_studentServices.GetStudentWithMaxAgeInClassroom(ClassroomId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}