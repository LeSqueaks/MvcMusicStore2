using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcMusicStore2.Models
{
    //Gets information from database
    public class MusicStoreEntities : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        //Added Step 8.  Exposes new Model classes
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        //Look back on if issues.  Commented during Step 8 to compile.
        //public System.Data.Entity.DbSet<MvcMusicStore2.Models.Artist> Artists { get; set; }
    }
}