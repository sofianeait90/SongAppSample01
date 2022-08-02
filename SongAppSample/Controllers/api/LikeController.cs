using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SongAppSample.Models;

namespace SongAppSample.Controllers.api
{
    public class LikeController : ApiController
    {
        private IdentifyContext _context;
        public LikeController()
        {
            _context = new IdentifyContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpPost]
        public async Task<SongLiked> Add()
        {
            try
            {
                int Id;
                var request = await Request.Content.ReadAsFormDataAsync();
                Int32.TryParse(request["SongId"], out Id);
                var existingLiked = !(_context.SongLikeds.Where(li => li.SongId == Id)).Any() ?null : (_context.SongLikeds.Where(li => li.SongId == Id)).First(); 
                //var existingLiked = _context.SongLikeds.First();
                var likedsong = new SongLiked() { SongId = Id,  };
                if (existingLiked == null)
                {
                    likedsong.IsLiked = true;
                    _context.SongLikeds.Add(likedsong);
                    _context.SaveChanges();
                return (likedsong);
                }
                else
                {
                    
                  
                    existingLiked.IsLiked = !existingLiked.IsLiked;
                    _context.SaveChanges();
                    return (existingLiked);
                  
                }
            }
            catch (Exception)
            {

                throw new HttpResponseException(HttpStatusCode.NotModified);
            }
            
            
            
            
            
        }
    }
}
