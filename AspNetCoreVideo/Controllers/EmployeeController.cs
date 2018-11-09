using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreVideo.Controllers
{
    //[Route("employee")]
    [Route("company/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        //[Route("")]
        //[Route("[action]")]
        public string Index()
        {
            return "Hello from Employee";
        }

        //[Route("name")]
        //[Route("[action]")]
        public ContentResult Name()
        {
            return Content("Justy");
        }

        //[Route("country")]
        //[Route("[action]")]
        public string Country()
        {
            return "USA";
        }
    }
}
