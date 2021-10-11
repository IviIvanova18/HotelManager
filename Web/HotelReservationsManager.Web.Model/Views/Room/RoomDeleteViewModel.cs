namespace HotelReservationsManager.Web.Model.Views.Room
{
    public class RoomDeleteViewModel
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsFree { get; set; }
        public double PriceForAdult { get; set; }
        public double PriceForChild { get; set; }
        public int RoomNumber { get; set; }
    }
}
