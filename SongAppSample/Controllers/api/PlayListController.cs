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
    
    public class PlayListController : ApiController
    {
        private readonly IdentifyContext _context;
        
        public PlayListController()
        {
            _context = new IdentifyContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //[Route("api/playlist")]
        //get api/playlist
            
        [HttpGet]
        public IEnumerable<PlayList> List()
        {
            return _context.PlayLists.ToList();

        }

        [HttpPost]
        public async Task< PlayListDetail>  Add()
        {

            var myRequest = await  Request.Content.ReadAsFormDataAsync();
            _ = new PlayListDetail();

            PlayListDetail _playlistDetail = CreatePlayListDetail(myRequest["songid"], myRequest["playlistid"]);
            try
            {

            _context.PlayListDetails.Add(_playlistDetail);
            _context.SaveChanges();
                return (_playlistDetail);
            }
            catch (Exception )
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
             }
            

        }

       

        private PlayListDetail CreatePlayListDetail(string songId, string playListId )
        {
            int _songId, _playListId;
            _songId = Int32.Parse(songId);
            _playListId = Int32.Parse(playListId);

            return new PlayListDetail { SongId = _songId, PlayListId = _playListId, DateAddedToPlaylist=DateTime.Now };
        }
    }
}
