using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingApi.Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext dataContext;

        public BookingRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Guid> CreateAsync(BookingTable booking)
        {
            booking.CreatedAt = DateTime.Now;

            this.dataContext.Bookings.Add(booking);
            await dataContext.SaveChangesAsync();

            return booking.Id;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingEntity>> GetAsync(DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public Task<BookingEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingTable> UpdateAsync(BookingTable bookingsTable)
        {
            throw new NotImplementedException();
        }
    }
}
