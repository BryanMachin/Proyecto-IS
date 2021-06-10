﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Data;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class SpecialDateController : Controller
    {
        private IRepository repository;

        public SpecialDateController(IRepository repository) => this.repository = repository;

        public IActionResult Index() => View(repository.SpecialDates);

        public ViewResult Edit(Guid SpecialDateID) => View(repository.SpecialDates.FirstOrDefault(m => m.SpecialDateID == SpecialDateID));

        [HttpPost]
        public ActionResult Edit(SpecialDate specialDate)
        {
            repository.SaveSpecialDate(specialDate);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", Guid.Empty);
        }

        public ActionResult Delete(Guid SpecialDateID)
        {
            repository.DeleteSpecialDate(SpecialDateID);
            return RedirectToAction("Index");
        }
        

    }
}
