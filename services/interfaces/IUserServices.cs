using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWebBasicPlatFrom.Dtos.User;
using Azure;

namespace ApiWebBasicPlatFrom.services.interfaces
{
    public interface IUserServices
    {

        ResponseToken Login (LoginDto input);
        void Create (CreateUserDto input);

    }
}