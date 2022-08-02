using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongAppSample.Models;
using System.Data.Entity;
using SongAppSample.Data;
using System.Threading.Tasks;

namespace SongAppSample.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IdentifyContext _context;
       
        private readonly AlbumData _albums;

        public ArtistController()
        {
            _context = new IdentifyContext();
            _albums = new AlbumData();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            _albums.Dispose();
           
        }

        // GET: Artist
        public async Task<ActionResult> Index(int Id)
        {

            var artists = _context.Artists.Where(art => art.Id == Id).First();
            var albums = await _albums.GetAlbumByArtist(Id);
            ViewBag.Albums = albums;
            ViewBag.Artist = artists;
            return View();
        }


        
    }
}