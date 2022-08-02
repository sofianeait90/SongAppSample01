using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SongAppSample.Data;
namespace SongAppSample.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        private SongData _songs;
        private AlbumData _album;
        public AlbumController()
        {
            _songs=new SongData();
            _album = new AlbumData();
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task <ActionResult> Details(int Id)
        {    
            var songs=await _songs.GetSongByAlbum(Id) ;
            var album =  _album.GetAlbum(Id);
            ViewBag.Songs = songs;
            ViewBag.Album = album;
            return View();
        }
    }
}