namespace HotelReservationsManager.Data
{
    using HotelReservationsManager.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public class HotelReservationsManagerDbContext : IdentityDbContext< User, IdentityRole, string>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }


        public HotelReservationsManagerDbContext(DbContextOptions<HotelReservationsManagerDbContext> options) : base(options)
        {
        }
    }
}
