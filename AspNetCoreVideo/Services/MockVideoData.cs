using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Models;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {
        private IEnumerable<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>
            {
                new Video { id = 1, Title = "Shrek" },
                new Video { id = 2, Title = "Despicable Me" },
                new Video { id = 3, Title = "Megamind" },
            };

        }

        public IEnumerable<Video> GetAll()
        {
            //throw new NotImplementedException();
            return _videos;
        }
    }
}
