using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Models;
using HotelReservationsManager.Web.Model.Views.Reservation;
using HotelReservationsManager.Web.Model.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservationsManager.Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HotelReservationsManagerDbContext hotelDbContext;

        public ReservationController(HotelReservationsManagerDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(ReservationCreateBindingModel reservationCreateBinding)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Reservation reservation = new Reservation
            {

                Id = Guid.NewGuid().ToString(),
                RoomNumber = reservationCreateBinding.RoomNumber,
                UserId = reservationCreateBinding.UserId,
                DateOfAccommodation = reservationCreateBinding.DateOfAccommodation,
                ReleaseDate = reservationCreateBinding.ReleaseDate,
                AllInclusive = reservationCreateBinding.AllInclusive,
                Breakfast = reservationCreateBinding.Breakfast
            };

            await this.hotelDbContext.AddAsync(reservation);
            await this.hotelDbContext.SaveChangesAsync();

            return Redirect("/");
        }
        public IActionResult Index()
        {
            List<ReservationViewModel> reservations = this.hotelDbContext.Reservations
               .Select(reservation => new ReservationViewModel
               {
                   RoomNumber = reservation.RoomNumber,
                   UserId = reservation.UserId,
                   DateOfAccommodation = reservation.DateOfAccommodation,
                   ReleaseDate = reservation.ReleaseDate,
                   Breakfast = reservation.Breakfast,
                   AllInclusive = reservation.AllInclusive,
                   Price = reservation.Price

               }).ToList();

            return View(reservations);
        }

        //[HttpGet]
        //public async Task<IActionResult> Details(string id)
        //{
        //    Reservation reservation = await this.hotelDbContext.Reservations
        //        .Include(reservation => reservation.RoomNumber)
        //        .SingleOrDefaultAsync(reservation => reservation.Id == id);

        //    ReservationDetailsViewModel reservationDetails = new ReservationDetailsViewModel
        //    {
        //        Id = reservation.Id,
        //        RoomNumber = reservation.RoomNumber,
        //        UserId = reservation.UserId,
        //        DateOfAccommodation = reservation.DateOfAccommodation,
        //        ReleaseDate = reservation.ReleaseDate,
        //        Breakfast = reservation.Breakfast,
        //        AllInclusive = reservation.AllInclusive,
        //        Price = reservation.Price

        //    };

        //    return this.View(reservationDetails);
        //}

        [HttpGet]
       
        public async Task<IActionResult> Edit(string id)
        {
            Reservation reservation = await this.hotelDbContext.Reservations
               .Include(reservation => reservation.RoomNumber)
               .SingleOrDefaultAsync(reservation => reservation.Id == id);

            ReservationEditCommonModel reservationEdit = new ReservationEditCommonModel
            {

                Id = reservation.Id,
                RoomNumber = reservation.RoomNumber,
                UserId = reservation.UserId,
                DateOfAccommodation = reservation.DateOfAccommodation,
                ReleaseDate = reservation.ReleaseDate,
                Breakfast = reservation.Breakfast,
                AllInclusive = reservation.AllInclusive,
                Price = reservation.Price
            };

            return View(reservationEdit);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(string id, ReservationEditCommonModel reservationEdit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Reservation reservation = await this.hotelDbContext.Reservations
                .Include(reservation => reservation.RoomNumber)
                .SingleOrDefaultAsync(reservation => reservation.Id == id);

            reservation.RoomNumber = reservationEdit.RoomNumber;
            reservation.UserId = reservationEdit.UserId;
            reservation.DateOfAccommodation = reservationEdit.DateOfAccommodation;
            reservation.ReleaseDate = reservationEdit.ReleaseDate;
            reservation.Breakfast = reservationEdit.Breakfast;
            reservation.AllInclusive = reservationEdit.AllInclusive;
            reservation.Price = reservationEdit.Price;

            this.hotelDbContext.Update(reservation);
            await this.hotelDbContext.SaveChangesAsync();

            return Redirect("/");
        }

        [HttpGet]

        public async Task<IActionResult> Delete(string id)
        {
            Reservation reservation = await this.hotelDbContext.Reservations
               .Include(reservation => reservation.RoomNumber)
               .SingleOrDefaultAsync(reservation => reservation.Id == id);

            ReservationDeleteViewModel reservationDelete = new ReservationDeleteViewModel
            {
                Id = reservation.Id,
                RoomNumber = reservation.RoomNumber,
                UserId = reservation.UserId,
                DateOfAccommodation = reservation.DateOfAccommodation,
                ReleaseDate = reservation.ReleaseDate,
                Breakfast = reservation.Breakfast,
                AllInclusive = reservation.AllInclusive,
                Price = reservation.Price
            };

            return View(reservationDelete);
        }

        [HttpPost]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete");
            }

            Reservation reservation = await this.hotelDbContext.Reservations
                .Include(reservation => reservation.RoomNumber)
                .SingleOrDefaultAsync(reservation => reservation.Id == id);

            this.hotelDbContext.Remove(reservation);
            await this.hotelDbContext.SaveChangesAsync();

            return Redirect("/");
        }
    }
}