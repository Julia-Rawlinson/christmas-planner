using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSecurity.Models;
using System.Threading.Tasks;

namespace WebSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        UserApi[] uservalue = new UserApi[]
        {
            new UserApi{UserId = 001,UserName ="Julia", UserPassword=""},
            new UserApi{UserId = 002,UserName ="Rita", UserPassword=""},
            new UserApi{UserId = 003,UserName ="Nikita", UserPassword=""},
            new UserApi{UserId = 004,UserName ="Navya", UserPassword=""},
            new UserApi{UserId = 005,UserName ="Mehboob", UserPassword=""},
        };

        public IEnumerable<UserApi> GetUserApIs()
        {
            return uservalue;
        }

    }
}
