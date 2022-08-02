using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongAppSample.Models
{
    public class SongLiked
    {
        public int Id { get; set; }
        public bool IsLiked { get; set; }
        public virtual Song Song { get; set; }
        public virtual int SongId { get; set; }
    }
}