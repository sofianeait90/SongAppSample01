using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SongAppSample.Models;

namespace SongAppSample.ViewModels
{
    public class SongViewModel
    {
        public int  SongId { get; set; }
        public string SongTitle { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? SongDateToAddToCollection { get; set; }
        public string GenreName { get; set; }
        public int AlbumID { get; set; }
        public string AlbumTitle { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int? PlayListId { get; set; }
        public string PlayListName { get; set; }
        public bool? Liked { get; set; }
        

    }
}