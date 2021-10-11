using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationsManager.Web.Model.Views.Client
{
    public class ClientDetailsViewModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public bool IsAdult { get; set; }
    }
}
