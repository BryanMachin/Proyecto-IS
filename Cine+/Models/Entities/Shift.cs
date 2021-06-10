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

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(16, ErrorMessage = "Limit of characters(16) exceeded")]
        public string Name { get; set; }


        public DateTime Time { get; set; }
    }
}
