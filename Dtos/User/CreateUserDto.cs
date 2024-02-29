using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Constant;
using ApiWebBasicPlatFrom.Utils;

namespace ApiWebBasicPlatFrom.Dtos.User
{
    public class CreateUserDto
    {
        private string _username;
        public string UserName {
            get => _username;
            set => _username?.Trim();
        }

        private string _password;
        public string Password {
            get => _password;
            set => _password?.Trim();
        }
        
        [IntegerRange(AllowableValues = new int[] { UserTypes.Admin, UserTypes.Customer })]
        public int UserType { get; set; }

    }
}