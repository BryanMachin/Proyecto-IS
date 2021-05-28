using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class Shift
    {
        [Key]
        public Guid ShiftID { get; set; }

        [Range(0,23,ErrorMessage ="Hour value not valid. Please enter an hour between 0 and 23")]
        public int Hour { get; set; }

        [Range(0, 59, ErrorMessage = "Minute value not valid. Please enter a minute between 0 and 59")]
        public int Minute { get; set; }
    }
}
