using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Data;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class SpecialUserController : Controller
    {
        private IRepository repository;

        public SpecialUserController(IRepository repository) => this.repository = repository;

        public IActionResult Index() => View(repository.SpecialUsers);

        public ViewResult Edit(Guid SpecialUserID) => View(repository.SpecialUsers.FirstOrDefault(m => m.SpecialUserID == SpecialUserID));

        [HttpPost]
        public ActionResult Edit(SpecialUser specialUser)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSpecialUser(specialUser);
                return RedirectToAction("Index");
            }
            else return View(specialUser);
            
        }

        public ActionResult Create() => View("Edit", new SpecialUser());
        

        public ActionResult Delete(Guid SpecialUserID)
        {
            repository.DeleteSpecialUser(SpecialUserID);
            return RedirectToAction("Index");
        }


    }
}
