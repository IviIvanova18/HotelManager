using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationsManager.Web.Model.Views.User
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string EGN { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }
}
