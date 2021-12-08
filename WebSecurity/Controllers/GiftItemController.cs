using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebSecurity.Models;
using System;

namespace WebSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftItemController : ControllerBase

    {
        GiftItemAPI[] giftvalue = new GiftItemAPI[]
        {
            new GiftItemAPI{GiftId = 001,GiftName ="Shoes"},
            new GiftItemAPI{GiftId = 002,GiftName ="Socks"},
            new GiftItemAPI{GiftId = 003,GiftName ="Candy Cane"},
            new GiftItemAPI{GiftId = 004,GiftName ="Chocolates"},
            new GiftItemAPI{GiftId = 005,GiftName ="Flowers"}
        };

        public IEnumerable<GiftItemAPI> GetGiftItemAPIs()
        {
            return giftvalue;
        }

        
    }
}
