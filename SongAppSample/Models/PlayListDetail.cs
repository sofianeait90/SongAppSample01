using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongAppSample.Models
{
    public class PlayListDetail
    {
        public int Id { get; set; }
        public virtual PlayList  PlayList { get; set; }
        public virtual int PlayListId { get; set; }
        public virtual Song Song { get; set; }
        public virtual int SongId { get; set; }
        public DateTime DateAddedToPlaylist { get; set; }
    }
}