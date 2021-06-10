using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.ViewModels;
using Cine_.Models.Relations;

namespace Cine_.Controllers
{
    public class RoomController : Controller
    {
        private IRepository repository;

        public RoomController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.Rooms);

        public ViewResult Edit(Guid RoomID) => View(repository.Rooms.FirstOrDefault(m => m.RoomID == RoomID));

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                var sameName = repository.Rooms.FirstOrDefault(r => r.Name == room.Name);
                if (sameName == null)
                {
                    repository.SaveRoom(room);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Room name already taken";
                    return View(room);
                }

            }
            else return View(room);
        }

        public ActionResult Create() => View("Edit", new Room());

        [HttpPost]
        public ActionResult Delete(Guid RoomID)
        {
            repository.DeleteRoom(RoomID);
            return RedirectToAction("Index");
        }


        public ViewResult Profile(Guid RoomID)
        {
            RoomDateViewModel viewModel = new RoomDateViewModel
            {
                Room = repository.Rooms.FirstOrDefault(r => r.RoomID == RoomID),
                Date = DateTime.Today
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RoomDate(RoomDateViewModel viewModelPost)
        {
            DateTime date = viewModelPost.Date;
            Room room = viewModelPost.Room;
            var presentations = repository.Presentations.Where(p => p.Date == date && p.RoomID == viewModelPost.Room.RoomID);

            List<Shift> shifts = repository.Shifts.ToList();
            List<Movie> programmedMovies = new List<Movie>();
            List<float> ticketPrices = new List<float>();

            bool temp = false;
            for (int i = 0; i < shifts.Count; i++)        
            {
                foreach (var item in presentations)
                    if (item.ShiftID == shifts[i].ShiftID)
                    {
                        programmedMovies.Add(repository.Movies.FirstOrDefault(m => m.MovieID == item.MovieID));
                        ticketPrices.Add(item.TicketPrice);
                        temp = true;
                        break;
                    }
                if (!temp)
                {
                    programmedMovies.Add(new Movie());
                    ticketPrices.Add(2);
                }
                else temp = false;
            }

            var movies = repository.Movies;

            RoomScheduleViewModel viewModel = new RoomScheduleViewModel
            {
                Room = room,
                Date = date,
                Shifts = shifts,
                ProgrammedMovies = programmedMovies,
                TicketPrices = ticketPrices,
                Movies = movies
            };
            return View("RoomSchedule", viewModel);
        }

        [HttpPost]
        public ActionResult RoomSchedule(RoomScheduleViewModel viewModelPost)
        {
            var presentations = repository.Presentations.Where(p => p.Date == viewModelPost.Date && p.Room.RoomID == viewModelPost.Room.RoomID).ToList();
            foreach (var item in presentations)
                repository.DeletePresentation(item.MovieID,item.RoomID,item.ShiftID,item.Date);

            for (int i = 0; i < viewModelPost.Shifts.Count; i++)
            {
                Presentation p = new Presentation
                {
                    ShiftID = viewModelPost.Shifts[i].ShiftID,
                    MovieID = viewModelPost.ProgrammedMovies[i].MovieID,
                    RoomID = viewModelPost.Room.RoomID,
                    Date = viewModelPost.Date,
                    TicketPrice = viewModelPost.TicketPrices[i],
                    Availability = viewModelPost.Room.Capacity
                };
                p.Shift = repository.Shifts.FirstOrDefault(s => s.ShiftID == p.ShiftID);
                p.Movie = repository.Movies.FirstOrDefault(s => s.MovieID == p.MovieID);
                p.Room = repository.Rooms.FirstOrDefault(s => s.RoomID == p.RoomID);

                repository.SavePresentation(p);
            }
            return RedirectToAction("Profile", new {RoomID = viewModelPost.Room.RoomID});
        }
    }
}
