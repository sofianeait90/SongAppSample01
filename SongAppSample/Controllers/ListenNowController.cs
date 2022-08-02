using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongAppSample.Data;

namespace SongAppSample.Controllers
{
    public class ListenNowController : Controller
    {

        private SongData _songs;
        public ListenNowController()
        {
            _songs = new SongData();

        }
        // GET: ListenNow
        public ActionResult Index(int Id)
        {
            if(Id != null || Id != 0)
            {
                var _=_songs.GetOneSong(Id);
                ViewBag.Song = _;
            }

            return View();
        }
    }
}