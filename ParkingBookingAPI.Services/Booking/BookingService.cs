using ParkingBookingApi.Entities;
using ParkingBookingApi.Repositories.BookingRepository;
using ParkingBookingApi.Services.Booking;
using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data.Tables;
using System.Reflection.Metadata.Ecma335;

namespace ParkingBookingAPI.Services.Booking
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<Guid> CreateBooking(BookingEntity booking)
        {
            var table = BookingTable.FromEntity(booking);

            var id = await this.bookingRepository.CreateAsync(table);

            return id;
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
