using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingAPI.Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        Task<int> GetExistingCountAsync(DateTime dateFrom, DateTime dateTo);

        Task<BookingEntity?> GetByIdAsync(Guid id);

        Task<Guid> CreateAsync(BookingTable bookingsTable);

        Task DeleteAsync(Guid id);

        Task<BookingEntity> UpdateAsync(BookingTable bookingsTable);
    }
}
