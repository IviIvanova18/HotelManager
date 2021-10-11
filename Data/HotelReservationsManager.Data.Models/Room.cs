using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationsManager.Data.Models
{
    public class Room
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public RoomType Type { get; set; }
        public bool IsFree { get; set; }
        public double PriceForAdult { get; set; }
        public double PriceForChild { get; set; }
        public int RoomNumber { get; set; }
    }
}
