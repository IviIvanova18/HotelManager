namespace HotelReservationsManager.Web.Model.Binding
{
    public class RoomCreateBindingModel
    {
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsFree { get; set; }
        public int PriceForAdult { get; set; }
        public int PriceForChild { get; set; }
        public int RoomNumber { get; set; }
        
    }
}
