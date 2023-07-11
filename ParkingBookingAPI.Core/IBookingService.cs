using ParkingBookingAPI.Entities;
using ParkingBookingAPI.Core.Entities;

namespace ParkingBookingAPI.Services.Booking
{
    public interface IBookingService
    {
        Task<AvailabilityEntity> GetBookingAvailability(BookingEntity booking);

        Task<Guid> CreateBooking(BookingEntity booking);

        Task<BookingEntity> UpdateBooking(BookingEntity booking);

        Task DeleteBooking(Guid bookingId);
    }
}
