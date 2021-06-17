using Rotativa;
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
    public class PurchaseController : Controller
    {
        private IRepository repository;
        public PurchaseController(IRepository repository) => this.repository = repository;

        public ViewResult Index() 
        {
            var purchases = repository.Purchases.ToList();
            List<PurchaseIndexViewModel> purchaseIndexViewModels = new List<PurchaseIndexViewModel>();
            foreach (Purchase purchase in purchases)
            {
                Client client = repository.Clients.FirstOrDefault(c => c.ClientID == purchase.ClientID); 
                purchaseIndexViewModels.Add(new PurchaseIndexViewModel
                {
                    ClientName = client.Name,
                    ClientLastName = client.LastName,
                    MovieTitle = repository.Movies.FirstOrDefault(m=>m.MovieID == purchase.MovieID).Title,
                    RoomName = repository.Rooms.FirstOrDefault(m => m.RoomID == purchase.RoomID).Name,
                    ShiftTime = repository.Shifts.FirstOrDefault(m => m.ShiftID == purchase.ShiftID).Time,
                    Date = purchase.Date,
                    PurchaseID = purchase.PurchaseID,
                });
            }
            return View();
        }
        public ViewResult Billboard() => View(repository.Movies);

        public ViewResult MovieDates(Guid MovieID)
        {
            List<Presentation> presentations = repository.Presentations.Where(p => p.MovieID == MovieID && p.Date.CompareTo(DateTime.Today) >= 0).ToList();
            foreach (var item in presentations)
                item.Shift = repository.Shifts.FirstOrDefault(s => s.ShiftID == item.ShiftID);


            ReservationViewModel viewModel = new ReservationViewModel
            {
                Presentations = presentations,
                Movie = repository.Movies.FirstOrDefault(m => m.MovieID == MovieID),
                ChosenPresentation = new Presentation()
            };
            return View(viewModel);
        }
        public ViewResult BuyTickets(Guid MovieID, Guid RoomID, Guid ShiftID, DateTime date)
        {
            PurchaseViewModel viewModel = new PurchaseViewModel
            {
                MovieID = MovieID,
                RoomID = RoomID,
                ShiftID = ShiftID,
                Date = date,
                Client = new Client(),
                Tickets = 0,
                SpecialUsers = repository.SpecialUsers.ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult BuyTickets(PurchaseViewModel viewModel)
        {
            viewModel.SpecialUsers = repository.SpecialUsers.ToList();
            if (ModelState.IsValid)
            {
                long.TryParse(viewModel.Client.IdentityNumber, out long parseResult);
                if (viewModel.Client.IdentityNumber.Length < 11 || parseResult == 0)
                {
                    ViewBag.ErrorMessage = "Please enter a valid 11-digit identity number";
                    return View(viewModel);
                }

                Presentation p = repository.Presentations.FirstOrDefault(p =>
                p.RoomID == viewModel.RoomID
                && p.MovieID == viewModel.MovieID
                && p.ShiftID == viewModel.ShiftID
                && p.Date == viewModel.Date);

                if (p.Availability < viewModel.Tickets)
                {
                    ViewBag.NoSeatsAvailable = $"Sorry, only {p.Availability} available seats left";
                    return View(viewModel);
                }

                else
                {
                    Client client = repository.Clients.FirstOrDefault(c => c.IdentityNumber == viewModel.Client.IdentityNumber);
                    if (client == null)
                        repository.SaveClient(viewModel.Client);
                    client = repository.Clients.FirstOrDefault(c => c.IdentityNumber == viewModel.Client.IdentityNumber);

                    SpecialUser specialUser = repository.SpecialUsers.FirstOrDefault(d => d.Name == viewModel.SpecialUserSelected);


                    PayTicketsViewModel payViewModel = new PayTicketsViewModel
                    {
                        ClientID = client.ClientID,
                        MovieID = p.MovieID,
                        RoomID = p.RoomID,
                        ShiftID = p.ShiftID,
                        Date = p.Date,
                        Tickets = viewModel.Tickets,
                        MoneyImport = viewModel.Tickets * p.TicketPrice,
                        PointsImport = viewModel.Tickets * 20,
                        SpecialUserSelected = viewModel.SpecialUserSelected
                    };
                    payViewModel.SpecialUserID = (specialUser == null) ? Guid.Empty : specialUser.SpecialUserID;
                    return View("PayTickets", payViewModel);
                }
            }
            else return View(viewModel);
        }


        [HttpPost]
        public ActionResult CalculateImport(PayTicketsViewModel viewModel)
        {
            if (viewModel.payWithPoints)
                viewModel.PointsImport = viewModel.Tickets * 20;

            else
            {
                viewModel.MoneyImport = viewModel.Tickets * repository.Presentations.FirstOrDefault(p => p.MovieID == viewModel.MovieID && p.RoomID == viewModel.RoomID
                && p.ShiftID == viewModel.ShiftID && p.Date == viewModel.Date).TicketPrice;

                SpecialDate specialDate = repository.SpecialDates.FirstOrDefault(d => d.Date == viewModel.Date);
                if (specialDate != null)
                    viewModel.MoneyImport -= (viewModel.MoneyImport * specialDate.DiscountRate) / 100;

                if (viewModel.SpecialUserID != Guid.Empty)
                    viewModel.MoneyImport -= (viewModel.MoneyImport * repository.SpecialUsers.FirstOrDefault(s => s.SpecialUserID == viewModel.SpecialUserID).DiscountRate) / 100;
            }
            return View(viewModel);
        }



        [HttpPost]
        public ActionResult PayTickets(PayTicketsViewModel viewModel)
        {
            Presentation p = repository.Presentations.FirstOrDefault(p =>
                p.MovieID == viewModel.MovieID
             && p.RoomID == viewModel.RoomID
             && p.ShiftID == viewModel.ShiftID
             && p.Date == viewModel.Date);

            if (p.Availability < viewModel.Tickets)
                ViewBag.ErrorMessage = "Sorry, there are not enough seats left for that many people";


            else if (viewModel.payWithPoints)
            {
                Membership clientMembership = repository.Memberships.FirstOrDefault(c => c.ClientID == viewModel.ClientID);
                if (clientMembership == null)
                    ViewBag.ErrorMessage = "Sorry, you are not a member. Please check our aplication form if you are interested on becoming one!";

                else if (viewModel.MembershipID != clientMembership.MembershipID)
                    ViewBag.ErrorMessage = "Sorry, your input membership identification does not match with the one on the database, please check it and try again";

                else if (clientMembership.Points < viewModel.PointsImport)
                    ViewBag.ErrorMessage = "Sorry, you do not have enough membership points";

                else
                {
                    clientMembership.Points -= viewModel.PointsImport;
                    clientMembership.Points += 5;
                    repository.SaveMembership(clientMembership);
                    Purchase purchase = new Purchase
                    {
                        ClientID = viewModel.ClientID,
                        MovieID = viewModel.MovieID,
                        RoomID = viewModel.RoomID,
                        ShiftID = viewModel.ShiftID,
                        Date = viewModel.Date,
                        MembershipID = clientMembership.MembershipID,
                        PointsImport = viewModel.PointsImport,
                        PurchaseID = Guid.NewGuid().ToString(),
                        Tickets = viewModel.Tickets,
                        SpecialUserSelected = viewModel.SpecialUserSelected
                    };
                    repository.SavePurchase(purchase);

                    p.Availability -= viewModel.Tickets;
                    repository.SavePresentation(p);


                   // Client client = repository.Clients.FirstOrDefault(client => client.ClientID == purchase.ClientID);
                   // SpecialDate dateDiscount = repository.SpecialDates.FirstOrDefault(d => d.Date.CompareTo(purchase.Date) == 0);
                   // PrintPurhcaseViewModel printPurhcaseViewModel = new PrintPurhcaseViewModel
                   // {
                   //     ClientName = client.Name,
                   //     ClientLastName = client.LastName,
                   //     RoomName = repository.Rooms.FirstOrDefault(r=>r.RoomID == purchase.RoomID).Name,
                   //     ShiftTime = repository.Shifts.FirstOrDefault(r => r.ShiftID == purchase.ShiftID).Time,
                   //     Date = purchase.Date,
                   //     PointsImport = purchase.PointsImport,
                   //     MoneyImport = 0,
                   //     UserDiscount = purchase.SpecialUserSelected,
                   //     DateDiscount = dateDiscount!= null ? dateDiscount.Name : "None",
                   //     MovieTitle = repository.Movies.FirstOrDefault(r => r.MovieID == purchase.MovieID).Title,
                   //     Tickets = purchase.Tickets
                   // };
                   // return 


                    return RedirectToAction("ClientIndex");
                }

            }
            else  //paying with credit  
            {
                if (viewModel.CreditCardID == null || viewModel.CreditCardID.Length != 12 || !long.TryParse(viewModel.CreditCardID, out long res)) 
                {
                    ViewBag.ErrorMessage = "Sorry, your input Credit Card ID is not valid, please enter a 12-digit id number";
                    return View("CalculateImport",viewModel);
                }
                

                Membership clientMembership = repository.Memberships.FirstOrDefault(c => c.ClientID == viewModel.ClientID);
                if (clientMembership != null)
                {
                    clientMembership.Points += 5;
                    repository.SaveMembership(clientMembership);
                }

                Purchase purchase = new Purchase
                {
                    ClientID = viewModel.ClientID,
                    MovieID = viewModel.MovieID,
                    RoomID = viewModel.RoomID,
                    ShiftID = viewModel.ShiftID,
                    Date = viewModel.Date,
                    CreditCardID = viewModel.CreditCardID,
                    MoneyImport = viewModel.MoneyImport,
                    PurchaseID = Guid.NewGuid().ToString(),
                    Tickets = viewModel.Tickets,
                    SpecialUserSelected = viewModel.SpecialUserSelected
                };
                repository.SavePurchase(purchase);

                p.Availability -= viewModel.Tickets;
                repository.SavePresentation(p);

                return RedirectToAction("ClientIndex");
            }
            return View("PayTickets", viewModel);
        }

        public ViewResult ReturnTickets() => View(new Client());

        [HttpPost]
        public ActionResult ReturnTickets(Client client)
        {
            if (!ModelState.IsValid)
                return View(client);
            Client bdClient = repository.Clients.FirstOrDefault(c => c.Name == client.Name && c.LastName == client.LastName && c.IdentityNumber == client.IdentityNumber);

            if (bdClient == null)
                return View("ClientPurchases", null);

            var purchases = repository.Purchases.Where(p => p.ClientID == bdClient.ClientID);
            List<ShowPurchaseViewModel> viewModel = new List<ShowPurchaseViewModel>();
            foreach (Purchase purchase in purchases)
            {
                viewModel.Add(new ShowPurchaseViewModel
                {
                    RoomID = purchase.RoomID,
                    MovieID = purchase.MovieID,
                    ShiftID = purchase.ShiftID,
                    ClientID = purchase.ClientID,
                    Date = purchase.Date,
                    MovieTitle = repository.Movies.FirstOrDefault(m => m.MovieID == purchase.MovieID).Title,
                    ShiftTime = repository.Shifts.FirstOrDefault(s => s.ShiftID == purchase.ShiftID).Time,
                    Tickets = purchase.Tickets,
                    PaidWithPoints = purchase.MoneyImport == 0,
                    Import = purchase.MoneyImport == 0 ? purchase.PointsImport : purchase.MoneyImport,
                });
            }
            return View("ClientPurchases", viewModel);
        }

        public ViewResult DeletePurchase(Guid ClientID, Guid MovieID, Guid RoomID, Guid ShiftID, DateTime Date)
        {
            DeletePurchaseViewModel viewModel = new DeletePurchaseViewModel
            {
                ClientID = ClientID,
                MovieID = MovieID,
                RoomID = RoomID,
                ShiftID = ShiftID,
                Date = Date,
                PurchaseID = repository.Purchases.FirstOrDefault(p => p.ClientID == ClientID
                && p.MovieID == MovieID && p.RoomID == RoomID && p.ShiftID == ShiftID && p.Date == Date).PurchaseID
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeletePurchase(DeletePurchaseViewModel viewModelPost)
        {
            if (viewModelPost.PurchaseID != viewModelPost.InputPurchaseID)
                ViewBag.ErrorMessage = "Wrong purchase identification, please try again";

            else if (DateTime.Today.AddDays(2).CompareTo(viewModelPost.Date) >= 0)
                ViewBag.RefundErrorMessage = "Sorry, we do not offer refund this close to the presentation. For more information read our Business Policy.";


            else 
            {
                Purchase purchase = repository.Purchases.FirstOrDefault(p =>
                   p.ClientID == viewModelPost.ClientID
                && p.MovieID == viewModelPost.MovieID
                && p.RoomID == viewModelPost.RoomID
                && p.ShiftID == viewModelPost.ShiftID
                && p.Date == viewModelPost.Date
                );

                if (purchase.PointsImport > 0)
                {
                    Membership membership = repository.Memberships.FirstOrDefault(c => c.ClientID == purchase.ClientID);
                    if (membership!= null)
                    {
                        membership.Points += purchase.PointsImport;
                        repository.SaveMembership(membership);
                    }
                }


                Presentation presentation = repository.Presentations.FirstOrDefault(p =>
                   p.MovieID == viewModelPost.MovieID
                && p.RoomID == viewModelPost.RoomID
                && p.ShiftID == viewModelPost.ShiftID
                && p.Date == viewModelPost.Date
                );
                
                presentation.Availability += purchase.Tickets;
                repository.SavePresentation(presentation);


                Client client = repository.Clients.FirstOrDefault(c => c.ClientID == viewModelPost.ClientID);
                return View("ReturnTickets",client);
            }

            return View(viewModelPost);
        }
    }
}
