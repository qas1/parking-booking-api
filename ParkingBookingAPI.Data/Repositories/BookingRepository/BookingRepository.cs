using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingApi.Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        public Task<Guid> CreateAsync(BookingTable bookingsTable)
        {
            throw new NotImplementedException();
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
