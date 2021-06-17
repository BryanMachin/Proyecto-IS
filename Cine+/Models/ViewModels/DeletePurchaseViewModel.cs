using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_.Models.ViewModels
{
    public class DeletePurchaseViewModel
    {
        public Guid ClientID { get; set; }
        public Guid MovieID { get; set; }
        public Guid RoomID { get; set; }
        public Guid ShiftID { get; set; }
        public DateTime Date { get; set; }
        public string PurchaseID { get; set; }
        public string InputPurchaseID { get; set; }

    }
}
