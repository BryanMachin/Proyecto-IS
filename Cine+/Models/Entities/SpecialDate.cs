using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class SpecialDate
    {
        [Key]
        public Guid SpecialDateID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Rate value must be between 0 and 100")]
        [Display(Name = "Discount Rate")]
        public float DiscountRate {get; set;}

    }
}
