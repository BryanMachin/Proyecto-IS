using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Cine_.Models.Relations
{
    public class Membership
    {
        [Key]
        public Guid ClientID { get; set; }
        [ForeignKey("ClientID")]
        
        public Client Client { get; set; }
        public string MembershipID { get; set; }
        public int Points { get; set; }

    }
}
