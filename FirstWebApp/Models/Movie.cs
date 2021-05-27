using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public int GenreId { get; set; }

        [Display(Name="Date of Release")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int Stock { get; set; }

    }   
}