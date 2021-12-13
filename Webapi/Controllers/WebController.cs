using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webapi.Controllers
{
    public class WebController : ApiController
    {
        private static List<string> addgifts = new List<string> { "socks", "chocolates", "shoes", "candycane", "flowers" };
        
        [HttpGet]
        public IEnumerable<string> GetGifts()
        {
               return addgifts;
        }
        [HttpGet]
        public string GetGiftsByIndex(int id)
        {
            return addgifts[2];
        }
        
    }
}
