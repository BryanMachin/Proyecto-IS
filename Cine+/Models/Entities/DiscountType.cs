using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class DiscountType
    {
        [Key]
        public Guid DiscountTypeID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Rate value must be between 0 and 100")]
        [Display(Name = "Discount Rate")]
        public float DiscountRate { get; set; } 
    }
}
