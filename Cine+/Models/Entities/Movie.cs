using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class Movie
    {
        [Key]
        public Guid MovieID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Title { get; set; }

        public float Rating { get; set; }

        [Required(ErrorMessage = "Please enter a nationality")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Nationality { get; set; }

       /*
        [Required(ErrorMessage = "Please enter a genre")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Genre { get; set; }
       */

        [Required(ErrorMessage = "Please enter a synopsis")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Synopsis { get; set; }



    }
}
