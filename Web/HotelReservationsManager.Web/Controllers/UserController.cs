using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManager.Data;
using HotelReservationsManager.Web.Model.Views.User;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationsManager.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly HotelReservationsManagerDbContext hotelDbContext;
        public UserController(HotelReservationsManagerDbContext hotelDbContext)
        {
            this.hotelDbContext = hotelDbContext;
        }
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeesList = this.hotelDbContext.Users
                .Select(employee => new EmployeeViewModel
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    Surname = employee.Surname,
                    EGN = employee.EGN,
                    DateOfAppointment = employee.DateOfAppointment,
                    DateOfDismissal = employee.DateOfDismissal
                   
                }).ToList();

            return View(employeesList);
        }
    }
}