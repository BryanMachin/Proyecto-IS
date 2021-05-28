using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class Genre
    {
        [Key]
        public Guid GenreID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }
    }
}
