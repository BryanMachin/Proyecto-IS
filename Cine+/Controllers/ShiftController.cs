using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class ShiftController : Controller
    {
        private IRepository repository;

        public ShiftController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.Shifts);

        public ViewResult Edit(Guid ShiftID) => View(repository.Shifts.FirstOrDefault(m => m.ShiftID == ShiftID));

        [HttpPost]
        public ActionResult Edit(Shift shift)
        {
            if (ModelState.IsValid)
            {
                repository.SaveShift(shift);
                return RedirectToAction("Index");
            }
            else
            {
                return View(shift);
            }
        }
        public ActionResult Create() => View("Edit", new Shift());

        [HttpPost]
        public ActionResult Delete(Guid ShiftID)
        {
            repository.DeleteShift(ShiftID);
            return RedirectToAction("Index");
        }

    }
}
