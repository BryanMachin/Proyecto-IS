using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cine_.Models.Relations
{
    public class Presentation
    {
        [Key]
        public Guid MovieID { get; set; }
        [ForeignKey("MovieID")]
        public Movie Movie { get; set; }

        [Key]
        public Guid ShiftID { get; set; }
        [ForeignKey("ShiftID")]
        public Shift Shift { get; set; }

        [Key]
        public Guid RoomID { get; set; }
        [ForeignKey("RoomID")]
        public Room Room { get; set; }

        [Key]
        public DateTime Date { get; set; }

        [Required]
        [Range(2, 20, ErrorMessage = "Price not valid")]
        public float TicketPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Availability { get; set; }
    }
}
