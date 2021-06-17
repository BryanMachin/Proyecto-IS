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

namespace Cine_.Controllers
{
    public class HomeClientController : Controller
    {
        private IRepository repository;
     
        private readonly ILogger<HomeClientController> _logger;

        public HomeClientController(ILogger<HomeClientController> logger, IRepository repository)
        {
            this.repository = repository;
            
            var oldPresentations = repository.Presentations.Where(p => DateTime.Compare(p.Date, DateTime.Now) <= 0).ToList();
            var oldPurchases = repository.Purchases.Where(p=> DateTime.Compare(p.Date, DateTime.Now) <= 0).ToList();
            foreach (Presentation presentation in oldPresentations)
                this.repository.DeletePresentation(presentation.MovieID, presentation.RoomID, presentation.ShiftID, presentation.Date);
            foreach (Purchase purchase in oldPurchases)
                this.repository.DeletePurchase(purchase.ClientID,purchase.MovieID, purchase.RoomID, purchase.ShiftID, purchase.Date);
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Recommendation() => View(repository.Movies.OrderByDescending(m => m.Rating).Take(10).ToList());
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
