using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_.Models.Entities
{
    public class Movie
    {
        [Key]
        public Guid MovieID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Title { get; set; }

        [Range(0,10,ErrorMessage ="Rating value must be between 0 and 10")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Please enter a nationality")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Nationality { get; set; }
       
        [Required(ErrorMessage = "Please enter a synopsis")]
        [StringLength(500, ErrorMessage = "Limit of characters(500) exceeded")]
        public string Synopsis { get; set; }

        [Display(Name = "Genre")]
        public Guid GenreID { get; set; }

        public string GenreName{ get; set; }


    }
}
