using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.Relations;

namespace Cine_.Models.ViewModels
{
    public class ReservationViewModel
    {
        public Movie Movie { get; set; }
        public Presentation ChosenPresentation { get; set; }
        public List<Presentation> Presentations { get; set; }

    }
}
