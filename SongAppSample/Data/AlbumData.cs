using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using SongAppSample.ViewModels;
using SongAppSample.Models;

namespace SongAppSample.Data
{
    public class AlbumData
    { 
        private readonly IdentifyContext _context;
        public AlbumData()
        {
            _context = new IdentifyContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async  Task<IEnumerable<AlbumViewModel>> GetAlbumByArtist(int Id)
        {
            var _albums = await (from album in _context.Albums
                                 where (album.ArtistId==Id)
                                 select new AlbumViewModel
                                 {
                                     AlbumID = album.Id == null ? 0 : album.Id,
                                     AlbumTitle = album.Title == null ? string.Empty: album.Title,
                                     //RealeseDate = album.RleaseDate == null ? string.Empty : album.RleaseDate.ToString("MMMM/YYYY")
                                 }
                                  ).ToListAsync();
            return _albums;
        
        }

        public Album GetAlbum(int Id)
        {
             var album = _context.Albums.Include(al=>al.Artist).Where(al => al.Id == Id).First();
            return album;
        }
      
    }
}