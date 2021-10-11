using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Models;
using HotelReservationsManager.Web.Model.Binding;
using HotelReservationsManager.Web.Model.Views.Client;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationsManager.Web.Controllers
{
    public class ClientController : Controller
    {

        private readonly HotelReservationsManagerDbContext hotelDbContext;

        public ClientController(HotelReservationsManagerDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }
        public IActionResult Index()
        {
            List<ClientDetailsViewModel> clientsList = this.hotelDbContext.Clients
               .Select(client => new ClientDetailsViewModel
               {
                   FirstName = client.FirstName,
                   Surname = client.Surname,
                   Mail = client.Mail,
                   PhoneNumber = client.PhoneNumber,
                   IsAdult = client.IsAdult

               }).ToList();

            return View(clientsList);
        }


        //[HttpGet]
        //public async Task<IActionResult> Details(string id)
        //{
        //    Client client = await this.hotelDbContext.Clients
        //        .Include(client => client.Mail)
        //        .SingleOrDefaultAsync(client => client.Id == id);

        //    ClientDetailsViewModel clientDetailsViewModel = new ClientDetailsViewModel
        //    {
        //        //Id = client.Id,
        //        FirstName = client.FirstName,
        //        Surname = client.Surname,
        //        Mail = client.Mail,
        //        PhoneNumber = client.PhoneNumber,
        //        IsAdult = client.IsAdult

        //    };

        //    return this.View(clientDetailsViewModel);
        //}
    }
}