using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationsManager.Data.Models
{
    public class Client
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public bool IsAdult { get; set; }
    }
}
