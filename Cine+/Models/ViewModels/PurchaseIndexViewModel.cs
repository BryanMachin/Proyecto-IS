using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_.Models.ViewModels
{
    public class PurchaseIndexViewModel
    {
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string MovieTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime ShiftTime { get; set; }
        public DateTime Date { get; set; }
        public string PurchaseID { get; set; }
    }
}
