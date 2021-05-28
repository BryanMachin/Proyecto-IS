using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cine_.Models.Entities
{
    public class SpecialUser
    {
        [Key]
        public Guid SpecialUserID { get; set; }
    }
}
