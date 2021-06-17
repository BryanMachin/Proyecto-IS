using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.Relations;
using System.ComponentModel.DataAnnotations;
namespace Cine_.Models.ViewModels
{
    public class PurchaseViewModel
    {
        public Guid MovieID { get; set; }
        public Guid RoomID { get; set; }
        public Guid ShiftID { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public int Tickets { get; set; }
        [Display(Name = "User type")]
        public string SpecialUserSelected { get; set; }
        public List<SpecialUser> SpecialUsers { get; set; }

    }
}
