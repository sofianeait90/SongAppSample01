using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongAppSample.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateEvent { get; set; }
        public string Location { get; set; }
        public bool Active { get; set; }

    }
}