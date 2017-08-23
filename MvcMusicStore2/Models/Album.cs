using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcMusicStore2.Models
{
    public class Album { 

        //Makes it so you don't show the AlbumId
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        //Changes name from GenreId to Genre
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        //Changes name from ArtistId to Artist
        [DisplayName("Artist")]
        public int ArtistId { get; set; }

        //Requires a Title and gives char limit
        [Required(ErrorMessage = "An Album Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        //Already added in a CD that costs $5000.00, come back to this if issues happen
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }

        //Does not say "required," just gives char limit parameters
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        //Genre and Artist go from public to public virtual.  This allows EF to "lazy-load" them as necessary
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
}
}