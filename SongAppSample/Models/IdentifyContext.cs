using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SongAppSample.Models
{
    public class IdentifyContext: IdentityDbContext
    {
        public IdentifyContext()
        :base(System.Configuration.ConfigurationManager.ConnectionStrings["SongApp"].ConnectionString)
        {
                
        }

        public DbSet <Song>Songs { get; set; }
        public DbSet <PlayList>PlayLists { get; set; }
        public DbSet <SongLiked>SongLikeds { get; set; }
        public DbSet <PlayListDetail>PlayListDetails { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}