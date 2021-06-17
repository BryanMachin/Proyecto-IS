using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Relations;
using Cine_.Models.Data;
using System.ComponentModel.DataAnnotations;
namespace Cine_.Models.ViewModels
{
    public class PayTicketsViewModel
    {
        public Guid ClientID { get; set; }
        public Guid MovieID { get; set; }
        public Guid RoomID { get; set; }
        public Guid ShiftID { get; set; }
        public DateTime Date { get; set; }
        public Guid SpecialUserID { get; set; }

        public int Tickets { get; set; }
        public bool payWithPoints { get; set; }
        public float MoneyImport { get; set; }
        public int PointsImport { get; set; }

        public string MembershipID { get; set; }
        public string CreditCardID { get; set; }
        public string SpecialUserSelected { get; set; }


    }
}
