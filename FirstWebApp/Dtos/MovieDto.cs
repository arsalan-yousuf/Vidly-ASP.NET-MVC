using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApp.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 20)]
        public int Stock { get; set; }
    }
}