using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.Services;


namespace AspNetCoreVideo.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        //public ObjectResult Index()
        private IVideoData _videos;

        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        public ViewResult Index()
        {
            //var model = new Video { id = 1, Title = "Shrek" };
            //return new ObjectResult(model);
            //var model = new List<Video>
            //{
            //    new Video { id = 1, Title = "Shrek" },
            //    new Video { id = 2, Title = "Despicable Me" },
            //    new Video { id = 3, Title = "Megamind" },
            //};
            var model = _videos.GetAll();
        
            return View(model);
        }
    }
}
