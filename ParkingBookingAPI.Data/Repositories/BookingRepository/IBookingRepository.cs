using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingApi.Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        Task<List<BookingEntity>> GetAsync(DateTime dateFrom, DateTime dateTo);

        Task<BookingEntity?> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(BookingTable bookingsTable);

        Task DeleteAsync(Guid id);

        Task<BookingTable> UpdateAsync(BookingTable bookingsTable);
    }
}
