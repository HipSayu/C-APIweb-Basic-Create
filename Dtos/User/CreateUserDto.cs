using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Constant;
using ApiWebBasicPlatFrom.Utils;

namespace ApiWebBasicPlatFrom.Dtos.User
{
    public class CreateUserDto
    {
        private string _username;
        [Required]
        [StringLength(30, ErrorMessage = "Tên tài khoản dài từ 3 đến 30 ký tự", MinimumLength = 3)]
        public string UserName {
            get => _username;
            set => _username = value?.Trim();
        }
        // [Required]
        // [StringLength(30, ErrorMessage = "Mật khẩu dài từ 3 đến 30 ký tự", MinimumLength = 3)]
        private string _password;
        public string Password {
            get => _password;
            set => _password = value?.Trim();
        }
        
        [IntegerRange(AllowableValues = new int[] { UserTypes.Admin, UserTypes.Customer })]
        public int UserType { get; set; }

    }
}