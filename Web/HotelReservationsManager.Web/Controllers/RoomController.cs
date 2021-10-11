using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Models;
using HotelReservationsManager.Web.Model.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelReservationsManager.Web.Model.Views.Room;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HotelReservationsManager.Web.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly HotelReservationsManagerDbContext hotelDbContext;

        public RoomController(HotelReservationsManagerDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }
        public IActionResult Index()
        {
            List<RoomHomeViewModel> roomList = this.hotelDbContext.Rooms
               .Select(room => new RoomHomeViewModel
               {
                   Id = room.Id,
                   Capacity = room.Capacity,
                   IsFree = room.IsFree,
                   PriceForAdult = room.PriceForAdult,
                   PriceForChild = room.PriceForChild,
                   RoomNumber = room.RoomNumber,
                   Type = room.Type.Name

               }).ToList();

            return View(roomList);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RoomCreateBindingModel roomCreateBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Room room = new Room
            {

                Id = Guid.NewGuid().ToString(),
                PriceForAdult = roomCreateBindingModel.PriceForAdult,
                PriceForChild = roomCreateBindingModel.PriceForChild,
                RoomNumber = roomCreateBindingModel.RoomNumber,
                Capacity = roomCreateBindingModel.Capacity,
                IsFree = roomCreateBindingModel.IsFree,
                Type = await hotelDbContext.RoomTypes.SingleOrDefaultAsync(roomType => roomType.Name == roomCreateBindingModel.Type)
            };

            await this.hotelDbContext.AddAsync(room);
            await this.hotelDbContext.SaveChangesAsync();

            return Redirect("/");
        }


        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Room room = await this.hotelDbContext.Rooms
                .Include(room => room.Type)
                .SingleOrDefaultAsync(room => room.Id == id);

            RoomDetailsViewModel roomDetails = new RoomDetailsViewModel
            {
                Id = room.Id,
                Capacity = room.Capacity,
                IsFree = room.IsFree,
                PriceForAdult = room.PriceForAdult,
                PriceForChild = room.PriceForChild,
                RoomNumber = room.RoomNumber


            };

            return this.View(roomDetails);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            Room room = await this.hotelDbContext.Rooms
                .Include(room => room.Type)
                .SingleOrDefaultAsync(room => room.Id == id);

            RoomEditCommonModel roomEdit = new RoomEditCommonModel
            {
                Capacity = room.Capacity,
                IsFree = room.IsFree,
                PriceForAdult = room.PriceForAdult,
                PriceForChild = room.PriceForChild,
                RoomNumber = room.RoomNumber,
                Type = room.Type.Name

            };

            return View(roomEdit);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, RoomEditCommonModel roomEdit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Room room = await this.hotelDbContext.Rooms
                .Include(room => room.Type)
                .SingleOrDefaultAsync(room => room.Id == id);

            room.PriceForAdult = roomEdit.PriceForAdult;
            room.IsFree = roomEdit.IsFree;
            room.PriceForChild = roomEdit.PriceForChild;
            room.Capacity = roomEdit.Capacity;
            room.RoomNumber = roomEdit.RoomNumber;
            room.Type = await this.hotelDbContext.RoomTypes.SingleOrDefaultAsync(RoomType => RoomType.Name == roomEdit.Type);

            this.hotelDbContext.Update(room);
            await this.hotelDbContext.SaveChangesAsync();

            return Redirect("/");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            Room room = await this.hotelDbContext.Rooms
                .Include(room => room.Type)
                .SingleOrDefaultAsync(room => room.Id == id);

            RoomDeleteViewModel roomDelete = new RoomDeleteViewModel
            {
                Capacity = room.Capacity,
                IsFree = room.IsFree,
                PriceForAdult = room.PriceForAdult,
                PriceForChild = room.PriceForChild,
                RoomNumber = room.RoomNumber,
            };

            return View(roomDelete);
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            if (!ModelState.IsValid)
            {
                return View("Delete");
            }

            Room room = await this.hotelDbContext.Rooms
                 .Include(room => room.Type)
                 .SingleOrDefaultAsync(room => room.Id == id);

            this.hotelDbContext.Remove(room);
            await this.hotelDbContext.SaveChangesAsync();

            return Redirect("/");
        }
    }
}