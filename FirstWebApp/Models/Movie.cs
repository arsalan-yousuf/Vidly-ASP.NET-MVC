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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public int GenreId { get; set; }

        [Display(Name="Date of Release")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        public int Stock { get; set; }

    }   
}