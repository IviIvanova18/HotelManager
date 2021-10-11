using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;

namespace HotelReservationsManager.Data.Models
{
    public class User : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string EGN { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public bool ActivStatus { get; set; }
        public DateTime DateOfDismissal { get; set; }


    }
}
