using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SongAppSample.Models;
using SongAppSample.ViewModels;
using SongAppSample.Data;
using System.Threading.Tasks;

namespace SongAppSample.Controllers
{
    public class SongController : Controller
    {

        private readonly SongData _songs;
        
        public SongController()

        {
            //linq 
            _songs = new SongData();
        }
        protected override void Dispose(bool disposing)
        {
            _songs.Dispose();
        }






        public ActionResult GetCard(int Id)
        {
            return PartialView("_songCard", _songs.GetOneSong(Id));
        }

        public async  Task<ActionResult> Index(string Id)
        {
            IEnumerable<SongViewModel> songs;
            //if search value is null
            if (!String.IsNullOrEmpty(Id))
                
            {
                songs = await _songs.GetSong(Id);
            }
            else
            {
                 songs =await  _songs.GetSongHome();
            }
      

           //return search value and songs 
            ViewBag.songs= songs.ToList();
            ViewBag.searchValue = Id;
            return View();

        }

        // GET: Song
        //public ActionResult  Index1(string Id)
        //{
        //    var TempSong = from song in _context.Songs
        //                   join playListDetail in _context.PlayListDetails on song.Id equals playListDetail.Song.Id into gs
        //                   from gsong in gs.DefaultIfEmpty()
        //                   select new
        //                   {
        //                       Id = song.Id,
        //                       playListDetail = gsong.Id,
        //                   };

        //    var songs = _context.Songs
        //                   .Include(s => s.Artist)
        //                   .Include(s => s.Genre)
        //                   .Include(s => s.Album);

        //    if (!String.IsNullOrEmpty(Id) )
        //    {
        //        songs = songs.Where(s => s.Title.Contains(Id) 
        //                                 || s.Artist.Name.Contains(Id)
        //                                 || s.Album.Title.Contains(Id));
        //    }
        //    ViewBag.songs = songs.ToList();
        //    ViewBag.searchValue = Id;
        //    return View();


        //}
    }
}