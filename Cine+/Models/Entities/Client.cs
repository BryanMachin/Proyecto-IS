using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class Client
    {
        [Key]
        public Guid ClientID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        [StringLength(127, ErrorMessage = "Limit of characters(127) exceeded")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an identity number")]
        [StringLength(11, ErrorMessage = "Limit of characters(11) exceeded")]   
        [Display(Name = "Identity Number")]
        public string IdentityNumber { get; set; }
    }
}
