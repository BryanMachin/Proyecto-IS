using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class GenreController : Controller
    {
        private IRepository repository;

        public GenreController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.Genres);

        public ViewResult Edit(Guid GenreID) => View(repository.Genres.FirstOrDefault(m => m.GenreID == GenreID));

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGenre(genre);
                return RedirectToAction("Index");
            }
            else
            {
                return View(genre);
            }
        }

        public ActionResult Create() => View("Edit", new Genre());

        [HttpPost]
        public ActionResult Delete(Guid GenreID)
        {
            repository.DeleteGenre(GenreID);
            return RedirectToAction("Index");
        }

    }
}
