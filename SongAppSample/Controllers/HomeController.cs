
using System.Linq;
using System.Web.Mvc;
using SongAppSample.Models;

namespace SongAppSample.Controllers
{
    public class HomeController : Controller
    {
        IdentifyContext _context;

        public HomeController()
        {
            _context = new IdentifyContext();


        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var even = _context.Events.Where(e => e.Active == true).First();
            ViewBag.Event = even;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}