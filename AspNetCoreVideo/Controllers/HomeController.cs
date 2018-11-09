using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreVideo.Models;


namespace AspNetCoreVideo.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        public ObjectResult Index()
        {
            var model = new Video { id = 1, Title = "Shrek" };
            return new ObjectResult(model);
        }
    }
}
