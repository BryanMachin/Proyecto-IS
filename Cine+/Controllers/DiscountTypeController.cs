using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class DiscountTypeController : Controller
    {
        private IRepository repository;

        public DiscountTypeController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.DiscountTypes);

        public ViewResult Edit(Guid DiscountTypeID) => View(repository.DiscountTypes.FirstOrDefault(m => m.DiscountTypeID == DiscountTypeID));

        [HttpPost]
        public ActionResult Edit(DiscountType discountType)
        {
            if (ModelState.IsValid)
            {
                repository.SaveDiscountType(discountType);
                return RedirectToAction("Index");
            }
            else
            {
                return View(discountType);
            }
        }

        public ActionResult Create() => View("Edit", new DiscountType());

        [HttpPost]
        public ActionResult Delete(Guid DiscountTypeID)
        {
            repository.DeleteDiscountType(DiscountTypeID);
            return RedirectToAction("Index");
        }

    }
}
