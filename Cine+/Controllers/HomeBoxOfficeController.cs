using Cine_.Models;
using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Relations;
using Cine_.Models.Entities;
using Cine_.Models.ViewModels;

namespace Cine_.Controllers
{
    
    public class HomeBoxOfficeController : Controller
    {
        private IRepository repository;
        private readonly ILogger<HomeBoxOfficeController> _logger;

        public HomeBoxOfficeController(ILogger<HomeBoxOfficeController> logger, IRepository repository)
        {
            this.repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult TodaysBillboard()
        {
            var todaysPresentations = repository.Presentations.Where(p => DateTime.Compare(p.Date, DateTime.Now) > 0
         && DateTime.Compare(p.Date.Date, DateTime.Today.Date) == 0);
            List<TodaysPresentationsViewModel> viewModel = new List<TodaysPresentationsViewModel>();
            foreach (Presentation presentation in todaysPresentations)
            {
                viewModel.Add(new TodaysPresentationsViewModel()
                {
                    MovieID = presentation.MovieID,
                    RoomID = presentation.RoomID,
                    ShiftID = presentation.ShiftID,
                    MovieTitle = repository.Movies.FirstOrDefault(m => m.MovieID == presentation.MovieID).Title,
                    RoomName = repository.Rooms.FirstOrDefault(m => m.RoomID == presentation.RoomID).Name,
                    ShiftTime = repository.Shifts.FirstOrDefault(m => m.ShiftID == presentation.ShiftID).Time,
                    TicketPrice = presentation.TicketPrice
                });
            }
            return View(viewModel);
        }
         
            
            
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
