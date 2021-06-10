using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.Relations;
namespace Cine_.Models.ViewModels
{
    public class RoomScheduleViewModel
    {
        public Room Room { get; set; }
        public DateTime Date { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<Movie> ProgrammedMovies { get; set; }
        public List<float> TicketPrices { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

    }
}
