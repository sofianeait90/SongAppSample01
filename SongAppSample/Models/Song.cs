using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongAppSample.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual Album Album { get; set; }
        public virtual int  AlbumId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual int GenreId { get; set; }
        public short TrackNumber { get; set; }
        public int VolumeNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DateAddedToCollecton { get; set; }

        

    }
}