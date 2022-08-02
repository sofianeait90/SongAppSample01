using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SongAppSample.Models;

namespace SongAppSample.Controllers
{    
    public class PlayListController : Controller
    {
        private readonly IdentifyContext  _context ;
        public PlayListController()
        {
            _context = new IdentifyContext();
        }

        protected override void Dispose(bool disposing)                                 
        {
            _context.Dispose();
        }


        public ActionResult Create(PlayList playlist)
        {   
            if (playlist.Name is null) return View();
            _context.PlayLists.Add(playlist);
            _context.SaveChanges();
            return RedirectToAction("Index", "PlayList");
           
        }
        
        
        // GET: PlayList
        public ActionResult Index()
        {  

            var playlist = _context.PlayLists.ToList();

            return View(playlist);
        }


    }
}