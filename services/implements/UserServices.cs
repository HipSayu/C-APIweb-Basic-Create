using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Constant;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Dtos.User;
using ApiWebBasicPlatFrom.Entites;
using ApiWebBasicPlatFrom.services.interfaces;
using ApiWebBasicPlatFrom.Utils;
using Microsoft.IdentityModel.Tokens;

namespace ApiWebBasicPlatFrom.services.implements
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context ;   
        private readonly ILogger _logger ;
        private readonly IConfiguration _configuration;

        public UserServices (ApplicationDbContext context, ILogger<UserServices> logger, IConfiguration configuration) 
        {
            _context = context;
            _logger = logger ;
            _configuration = configuration;
        }

        public void Create(CreateUserDto input)
        {
            if(_context.Users.Any( u => u.UserName == input.UserName))
            {
                throw new NotImplementedException($"Tên tài khoản \"{input.UserName}\" đã tồn tại");
            }
            _context.Users.Add (new User {
                UserName = input.UserName,
                Password = CommonUtils.CreateMD5(input.Password),
                UserType = input.UserType
            });
           _context.SaveChanges();
        }

        public ResponseToken Login(LoginDto input)
        {
            var user = _context.Users.FirstOrDefault (u => u.UserName == input.UserName);
            if (user == null)
            {
                throw new NotImplementedException($"Tài khoản \"{input.UserName}\" không tồn tại");
            }
             if (CommonUtils.CreateMD5(input.Password) == user.Password)
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var claims = new List<Claim> 
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.IdUser.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(CustomClaimTypes.UserType, user.UserType.ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddSeconds(_configuration.GetValue<int>("JWT:Expires")),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return new ResponseToken {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }

            else 
            {
                throw new NotImplementedException($"Mật khẩu không chính xác");
            }
        }
    }
}