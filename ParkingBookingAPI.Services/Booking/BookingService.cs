using ParkingBookingApi.Entities;
using ParkingBookingApi.Repositories.BookingRepository;
using ParkingBookingApi.Services.Booking;
using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Core.Exceptions;
using ParkingBookingAPI.Data.Tables;
using Constants = ParkingBookingAPI.Data.Constants;

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
            this.ValidateDateTimes(booking.DateFrom, booking.DateTo);

            var availableSpaces = await this.GetAvailableSpaces(booking);
            if (availableSpaces == 0)
            {
                throw new UnprocessableEntityException($"There are no available parking spaces between {booking.DateFrom} and {booking.DateTo}");
            }

            var table = BookingTable.FromEntity(booking);

            var id = await this.bookingRepository.CreateAsync(table);

            return id;
        }

        private async Task<int> GetAvailableSpaces(BookingEntity booking)
        {
            var existingBookings = await this.bookingRepository.GetAsync(booking.DateFrom, booking.DateTo);

            var availableSpaces = Constants.ParkingMaxCapacity - existingBookings.Count();

            return availableSpaces;
        }

        private void ValidateDateTimes(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom < DateTime.Now || dateTo < DateTime.Now)
            {
                throw new UnprocessableEntityException("At least 1 of the datetimes provided are in the past.");
            }

            if (dateFrom >= dateTo)
            {
                throw new UnprocessableEntityException("DateTo must be after DateFrom.");
            }
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
