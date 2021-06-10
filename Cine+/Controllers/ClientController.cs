using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;

namespace Cine_.Controllers
{
    public class ClientController : Controller
    {
        private IRepository repository;

        public ClientController(IRepository repository) => this.repository = repository;

        public ViewResult Index() => View(repository.Clients);

        public ViewResult Edit(Guid ClientID) => View(repository.Clients.FirstOrDefault(m => m.ClientID == ClientID));

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                repository.SaveClient(client);
                return RedirectToAction("Index");
            }
            else
            {
                return View(client);
            }
        }

        public ActionResult Create() => View("Edit", new Client());

        [HttpPost]
        public ActionResult Delete(Guid ClientID) 
        {
            repository.DeleteClient(ClientID);
            return RedirectToAction("Index");
        }

    }
}
