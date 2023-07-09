using Microsoft.EntityFrameworkCore;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<BookingTable> Bookings => Set<BookingTable>();
    }
}
