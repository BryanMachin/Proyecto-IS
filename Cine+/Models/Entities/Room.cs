using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class Room
    {
        [Key]
        public Guid RoomID { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a non-negative value")]
        public int Capacity { get; set; }
    }
}
