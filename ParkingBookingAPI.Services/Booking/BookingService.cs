using ParkingBookingApi.Entities;
using ParkingBookingApi.Services.Booking;
using ParkingBookingAPI.Core.Entities;

namespace ParkingBookingAPI.Services.Booking
{
    public class BookingService : IBookingService
    {
        public Task<Guid> CreateBooking(BookingEntity booking)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBooking(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<AvailabilityEntity> GetBookingAvailability(BookingEntity booking)
        {
            throw new NotImplementedException();
        }

        public Task<BookingEntity> UpdateBooking(BookingEntity booking)
        {
            throw new NotImplementedException();
        }
    }
}
