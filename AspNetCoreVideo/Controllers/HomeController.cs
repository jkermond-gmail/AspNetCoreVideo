using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreVideo.Services;
using AspNetCoreVideo.Models;
using AspNetCoreVideo.ViewModels;
using AspNetCoreVideo.Entities;

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
            //var model = _videos.GetAll();

            var model = _videos.GetAll().Select(video =>
                new VideoViewModel
                {
                    Id = video.Id,
                    Title = video.Title,
                    //Genre = Enum.GetName(typeof(Genres), video.GenreId)
                    Genre = video.Genre.ToString()
                }
            );
        
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);
            //return new OkObjectResult(model);

            if (model == null)
                return RedirectToAction("Index");

            return View(new VideoViewModel
            {
                Id = model.Id,
                Title = model.Title,
                //Genre = Enum.GetName(typeof(Genres), model.GenreId)
                Genre = model.Genre.ToString()
            }
            );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Title = model.Title,
                    Genre = model.Genre
                };

                _videos.Add(video);

                //return View();
                return RedirectToAction("Details", new { id = video.Id });
            }

            return View();
        }
    }
}
