using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_.Models.ViewModels
{
    public class PrintPurhcaseViewModel
    {
        public string MovieTitle { get; set; }
        public string RoomName { get; set; }
        public DateTime ShiftTime { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public int Tickets { get; set; }
        public string UserDiscount { get; set; }
        public string DateDiscount { get; set; }
        public float MoneyImport { get; set; }
        public int PointsImport { get; set; }
    }
}
