using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SongAppSample.ViewModels;
using SongAppSample.Models;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;


namespace SongAppSample.Data
{
    public  class SongData
    {

        private readonly IdentifyContext _context;
        public SongData()
        {
            _context = new IdentifyContext();
        }

        public async Task<IEnumerable<SongViewModel>> GetSongHome()
        {
            var  songs =  await ((from song in _context.Songs.Take(50)
                                                      join playListDetail in _context.PlayListDetails on song.Id equals playListDetail.Song.Id into gs
                                                      from gsong in gs.DefaultIfEmpty()
                                                      join playLis in _context.PlayLists on gsong.PlayList.Id equals playLis.Id into pl
                                                      from playlist in pl.DefaultIfEmpty()
                                                      join liked in _context.SongLikeds on song.Id equals liked.Song.Id into lk
                                                      from like in lk.DefaultIfEmpty()

                                                      select new SongViewModel
                                                      {
                                                          SongId = song.Id == null ? 0 : song.Id,

                                                          SongTitle = song.Title == null ? string.Empty : song.Title,
                                                          //SongDateToAddToCollection = song.DateAddedToCollecton.ToString() == null ? string.Empty : song.DateAddedToCollecton.ToString(),
                                                          GenreName = song.Genre.Name == null ? string.Empty : song.Genre.Name,
                                                          AlbumID = song.Album.Id == null ? 0 : song.Album.Id,
                                                          AlbumTitle = song.Album.Title == null ? string.Empty : song.Album.Title,
                                                          ArtistId = song.Artist.Id == null ? 0 : song.Artist.Id,
                                                          ArtistName = song.Artist.Name == null ? string.Empty : song.Artist.Name,
                                                          PlayListId = playlist.Id == null ? 0 : playlist.Id,
                                                          PlayListName = playlist.Name == null ? string.Empty : playlist.Name,
                                                          Liked = like.IsLiked != null && like.IsLiked,






                                                      })).ToListAsync();
             return  songs;



        } 
        public SongViewModel GetOneSong(int Id)
        {
            var songs = ((from song in _context.Songs
                          join playListDetail in _context.PlayListDetails on song.Id equals playListDetail.Song.Id into gs
                          from gsong in gs.DefaultIfEmpty()
                          join playLis in _context.PlayLists on gsong.PlayList.Id equals playLis.Id into pl
                          from playlist in pl.DefaultIfEmpty()
                          join liked in _context.SongLikeds on song.Id equals liked.Song.Id into lk
                          from like in lk.DefaultIfEmpty()
                          where (song.Id == Id)
                          select new SongViewModel
                          {
                              SongId = song.Id == null ? 0 : song.Id,

                              SongTitle = song.Title == null ? string.Empty : song.Title,
                              SongDateToAddToCollection=song.DateAddedToCollecton,
                              GenreName = song.Genre.Name == null ? string.Empty : song.Genre.Name,
                              AlbumID = song.Album.Id == null ? 0 : song.Album.Id,
                              AlbumTitle = song.Album.Title == null ? string.Empty : song.Album.Title,
                              ArtistId = song.Artist.Id == null ? 0 : song.Artist.Id,
                              ArtistName = song.Artist.Name == null ? string.Empty : song.Artist.Name,
                              PlayListId = playlist.Id,
                              PlayListName = playlist.Name == null ? string.Empty : playlist.Name,
                              Liked = like.IsLiked,






                          })).First();
             return (SongViewModel) songs;



        } 

        public async   Task<IEnumerable<SongViewModel>> GetSong(string SearchValue)
        {
            var  songs =  await ((from song in _context.Songs
                                                      join playListDetail in _context.PlayListDetails on song.Id equals playListDetail.Song.Id into gs
                                                      from gsong in gs.DefaultIfEmpty()
                                                      join playLis in _context.PlayLists on gsong.PlayList.Id equals playLis.Id into pl
                                                      from playlist in pl.DefaultIfEmpty()
                                                      join liked in _context.SongLikeds on song.Id equals liked.Song.Id into lk
                                                      from like in lk.DefaultIfEmpty()
                                                      where (song.Title.Contains(SearchValue)
                                                              ||song.Artist.Name.Contains(SearchValue)
                                                              ||song.Album.Title.Contains(SearchValue)
                                                              )
                                                      select new SongViewModel
                                                      {
                                                          SongId = song.Id == null ? 0 : song.Id,

                                                          SongTitle = song.Title == null ? string.Empty : song.Title,
                                                          //SongDateToAddToCollection = song.DateAddedToCollecton.ToString() == null ? string.Empty : song.DateAddedToCollecton.ToString(),
                                                          GenreName = song.Genre.Name == null ? string.Empty : song.Genre.Name,
                                                          AlbumID = song.Album.Id == null ? 0 : song.Album.Id,
                                                          AlbumTitle = song.Album.Title == null ? string.Empty : song.Album.Title,
                                                          ArtistId = song.Artist.Id == null ? 0 : song.Artist.Id,
                                                          ArtistName = song.Artist.Name == null ? string.Empty : song.Artist.Name,
                                                          PlayListId = playlist.Id == null ? 0 : playlist.Id,
                                                          PlayListName = playlist.Name == null ? string.Empty : playlist.Name,
                                                          Liked = like.IsLiked != null && like.IsLiked,






                                                      })).ToListAsync();
             return  songs;



        }

        public async Task<IEnumerable<SongViewModel>>  GetSongByAlbum(int albumId)
        {
            var songs = await  ((from song in _context.Songs
                          join playListDetail in _context.PlayListDetails on song.Id equals playListDetail.Song.Id into gs
                          from gsong in gs.DefaultIfEmpty()
                          join playLis in _context.PlayLists on gsong.PlayList.Id equals playLis.Id into pl
                          from playlist in pl.DefaultIfEmpty()
                          join liked in _context.SongLikeds on song.Id equals liked.Song.Id into lk
                          from like in lk.DefaultIfEmpty()
                          where(song.Album.Id== albumId)
                          select new SongViewModel
                          {
                              SongId = song.Id == null ? 0 : song.Id,
                              SongTitle = song.Title == null ? string.Empty : song.Title,
                              //SongDateToAddToCollection = song.DateAddedToCollecton.ToString() == null ? string.Empty : song.DateAddedToCollecton.ToString(),
                              GenreName = song.Genre.Name == null ? string.Empty : song.Genre.Name,
                              AlbumID = song.Album.Id == null ? 0 : song.Album.Id,
                              AlbumTitle = song.Album.Title == null ? string.Empty : song.Album.Title,
                              ArtistId = song.Artist.Id == null ? 0 : song.Artist.Id,
                              ArtistName = song.Artist.Name == null ? string.Empty : song.Artist.Name,
                              PlayListId = playlist.Id == null ? 0 : playlist.Id,
                              PlayListName = playlist.Name == null ? string.Empty : playlist.Name,
                              Liked = like.IsLiked != null && like.IsLiked,
                              
                           })).ToListAsync();

            return (IEnumerable<SongViewModel>)songs;
        }

        public void Dispose()
        {
            _context.Dispose();
        } 

    }
}