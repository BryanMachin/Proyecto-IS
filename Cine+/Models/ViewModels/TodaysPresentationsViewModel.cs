using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_.Models.ViewModels
{
    public class TodaysPresentationsViewModel
    {
        public Guid MovieID { get; set; }
        public string MovieTitle { get; set; }
        public Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public Guid ShiftID { get; set; }
        public DateTime ShiftTime { get; set; }
        public float TicketPrice { get; set; }

    }
}
