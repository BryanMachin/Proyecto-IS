using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cine_.Models.Entities;
namespace Cine_.Models.Relations
{
    public class Purchase
    {
        [Key]
        public Guid ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }

        [Key]
        public Guid MovieID { get; set; }
        [Key]
        public Guid RoomID { get; set; }
        [Key]
        public Guid ShiftID { get; set; }
        [Key]
        public DateTime Date { get; set; }

        [ForeignKey("MovieID,RoomID,ShiftID,Date")]
        public Presentation Presentation { get; set; }
        


        public int Tickets { get; set; }
        public string PurchaseID { get; set; }
        public float MoneyImport { get; set; }
        public int PointsImport { get; set; }
        public string MembershipID { get; set; }
        public string CreditCardID { get; set; }
        public string SpecialUserSelected { get; set; }

    }
}
