using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongAppSample.Models;

namespace SongAppSample.Controllers
{
    public class LikedSongController : Controller
    {
        private  IdentifyContext _context;
        public LikedSongController()
        {
            _context = new IdentifyContext();
        }

        protected override void Dispose(bool disposing)
        {
            
            _context.Dispose();
        }

        // GET: LikedSong
        public ActionResult Index()
        {

            var likedSong = _context.SongLikeds.ToList() ;

            return View(likedSong);
        }
    }
}