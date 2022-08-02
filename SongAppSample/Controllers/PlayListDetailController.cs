using SongAppSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SongAppSample.Controllers
{
    public class PlayListDetailController : Controller
    {

        private readonly IdentifyContext _context;

        public PlayListDetailController()
        {

            _context = new IdentifyContext();
        }
        protected override void Dispose(bool disposing)
        {
            
            _context.Dispose();
        }

        // GET: PlayListDetail
        public ActionResult Index(int Id)
        {
                var songInPlayList = GetSongInPlayList(Id) ;

                ViewBag.PlayListSong = songInPlayList.OrderBy(p => p.Song.Title);
                ViewBag.PlayListName = getPlayListName(Id) ;
                return View();
            

            
        }

        private string getPlayListName(int Id)
        {
           return _context.PlayLists.Where(pl=>pl.Id==Id).First().Name;
        }

     

        private List<PlayListDetail> GetSongInPlayList(int Id)
        {
            return
                _context.PlayListDetails
                                 .Include(pls => pls.Song)
                                 .Include(pls => pls.Song.Artist)
                                 .Include(pls => pls.Song.Album)
                                 .Include(pls => pls.Song.Genre)
                                 .Include(pls => pls.PlayList)
                                 .Where(pls => pls.PlayList.Id == Id).ToList();
        }
    }
}