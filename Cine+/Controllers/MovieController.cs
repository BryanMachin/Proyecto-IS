using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Data;
using Cine_.Models.Entities;
using Cine_.Models.ViewModels;
using Cine_.Models.Relations;

namespace Cine_.Controllers
{
    public class MovieController : Controller
    {
        private IRepository repository;

        public MovieController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.Movies);

        public ViewResult Edit(Guid MovieID)
        {
            EditMovieViewModel viewModel = new EditMovieViewModel
            {
                Genres = repository.Genres
            };
            if (MovieID.CompareTo(Guid.Empty) == 0)
                viewModel.Movie = new Movie()
;
            else viewModel.Movie = repository.Movies.FirstOrDefault(m => m.MovieID == MovieID);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditMovieViewModel viewModel)
        {
            Movie movie = viewModel.Movie;
            if (ModelState.IsValid)
            {
                repository.SaveMovie(movie);
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.Genres = repository.Genres;
                return View(viewModel);
            }
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", Guid.Empty);
        }

        public ActionResult Delete(Guid MovieID)
        {
            repository.DeleteMovie(MovieID);
            return RedirectToAction("Index");
        }
        public ViewResult Profile(Guid MovieID) => View(repository.Movies.FirstOrDefault(m => m.MovieID == MovieID));



    }   
}
