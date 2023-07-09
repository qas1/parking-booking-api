using Moq;
using ParkingBookingApi.Repositories.BookingRepository;
using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data.Tables;
using ParkingBookingAPI.Services.Booking;

namespace ParkingBookingAPI.Tests
{
    public class BookingServiceTests
    {
        private readonly BookingService bookingService;
        private readonly Mock<IBookingRepository> bookingRepositoryMock = new Mock<IBookingRepository>();

        public BookingServiceTests()
        {
            this.bookingService = new BookingService(bookingRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateBooking_ShouldReturnId_WhenCreatingBooking()
        {
            // Arrange
            var booking = new BookingEntity
            {
                DateFrom = DateTime.Now.AddHours(1),
                DateTo = DateTime.Now.AddHours(2)
            };

            var bookings = new List<BookingEntity>();
            this.bookingRepositoryMock.Setup(x => x.GetAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                                      .ReturnsAsync(bookings);

            var newBookingId = Guid.NewGuid();
            // var table = BookingsTable.FromEntity(booking);
            this.bookingRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<BookingTable>()))
                                      .ReturnsAsync(newBookingId);

            // Act
            var response = await this.bookingService.CreateBooking(booking);

            // Assert
            Assert.Equal(newBookingId, response);
        }
    }
}