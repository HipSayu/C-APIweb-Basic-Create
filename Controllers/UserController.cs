using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Dtos.User;
using ApiWebBasicPlatFrom.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebBasicPlatFrom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        private IUserServices _userServices ;
        public UserController (IUserServices userServices, ILogger<UserController> logger) : base(logger)
        {
            _userServices = userServices;
        }
        [HttpPost("Login")]
        public ActionResult Login (LoginDto input) {
            try {
                return Ok(_userServices.Login(input));
            }
            catch (Exception ex) {
                return HandleException(ex) ;
            }
        }
        [HttpPost("CreateUser")]
        public ActionResult CreateUser (CreateUserDto input) {
            try {
                _userServices.Create(input);
                return Ok() ;
            }
            catch (Exception ex) {
                return HandleException(ex) ;
            }
        }

    }
}