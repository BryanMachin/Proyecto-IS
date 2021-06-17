using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_.Models.ViewModels
{
    public class ShowPurchaseViewModel
    {
        public string MovieTitle { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShiftTime { get; set; }
        public int Tickets { get; set; }
        public bool PaidWithPoints { get; set; }
        public float Import { get; set; }



        public Guid ClientID { get; set; }
        public Guid MovieID { get; set; }
        public Guid RoomID { get; set; }
        public Guid ShiftID { get; set; }
    }
}
