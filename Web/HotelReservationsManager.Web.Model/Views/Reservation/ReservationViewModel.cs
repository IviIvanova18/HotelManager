using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationsManager.Web.Model.Views.Reservation
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfAccommodation { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Breakfast { get; set; }
        public bool AllInclusive { get; set; }
        public double Price { get; set; }
    }
}
