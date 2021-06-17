using Cine_.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine_.Models.Entities;
using Cine_.Models.Relations;
using Cine_.Models.ViewModels;

namespace Cine_.Controllers
{
    public class MembershipController : Controller
    {
        private IRepository repository;

        public MembershipController(IRepository repository) => this.repository = repository;

        public ViewResult Index()
        {
            var memberships = repository.Memberships;
            List<MembershipIndexViewModel> viewModel = new List<MembershipIndexViewModel>();
            foreach (var item in memberships)
            {
                Client client = repository.Clients.FirstOrDefault(c => c.ClientID == item.ClientID);
                viewModel.Add(new MembershipIndexViewModel
                {
                    Name = client.Name,
                    LastName = client.LastName,
                    MembershipID = item.MembershipID,
                    Points = item.Points
                });
            }
            return View(viewModel);
        }

        public ViewResult Subscribe() => View(new Client());

        [HttpPost]
        public ActionResult Subscribe(Client client)
        {
            if (!ModelState.IsValid)
                return View(client);


            Client bdclient = repository.Clients.FirstOrDefault(c =>
            c.IdentityNumber == client.IdentityNumber && c.LastName == client.LastName && c.Name == client.Name);

            if (bdclient == null)
            {
                repository.SaveClient(client);

                bdclient = repository.Clients.FirstOrDefault(c =>
            c.IdentityNumber == client.IdentityNumber && c.LastName == client.LastName && c.Name == client.Name);
            }

            Membership membership = repository.Memberships.FirstOrDefault(c => c.ClientID == bdclient.ClientID);
            if (membership != null)
            {
                ViewBag.ErrorMessage = "This client is already a member of Cine +";
                return View(client);
            }

            membership = new Membership
            {
                Client = bdclient,
                ClientID = bdclient.ClientID,
                MembershipID = Guid.NewGuid().ToString()
            };
            repository.SaveMembership(membership);
            return RedirectToAction("Index", "HomeClient");
        }

        public ViewResult Unsubscribe() => View(new UnsubscribeViewModel {MembershipID = " "});

        [HttpPost]
        public ActionResult Unsubscribe(UnsubscribeViewModel viewModel)
        {
            Membership membership = repository.Memberships.FirstOrDefault(m => m.MembershipID == viewModel.MembershipID);
            if (membership == null)
            {
                ViewBag.ErrorMessage = "No member found with that ID, please check it and try again";
                return View();
            }
            repository.DeleteMembership(membership.ClientID);
            return RedirectToAction("Index", "HomeClient");
        }

        [HttpPost]
        public ActionResult Delete(Guid MembershipID)
        {
            
            repository.DeleteMembership(repository.Memberships.FirstOrDefault(m=>m.MembershipID == MembershipID.ToString()).ClientID);
            return RedirectToAction("Index");
        }

    }
}
