using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Data;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class MovieController : Controller
    {
        private IRepository repository;

        public MovieController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.Movies);

        public ViewResult Edit(Guid ID) => View(repository.Movies.FirstOrDefault(m => m.MovieID == ID));

        [HttpPost]
        public ActionResult Edit(Movie movie) 
        {
            if (ModelState.IsValid)
            {
                repository.SaveMovie(movie);
                return RedirectToAction("Index");
            }
            else 
            {
                return View(movie);
            }
        }

        public ActionResult Create() => View("Edit", new Movie());

    }
}
