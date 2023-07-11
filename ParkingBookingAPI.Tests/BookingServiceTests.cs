using Moq;
using ParkingBookingAPI.Repositories.BookingRepository;
using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Core.Exceptions;
using ParkingBookingAPI.Data;
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
        public async Task CreateBooking_WhenCreatingBooking_ShouldReturnId()
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
            this.bookingRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<BookingTable>()))
                                      .ReturnsAsync(newBookingId);

            // Act
            var response = await this.bookingService.CreateBooking(booking);

            // Assert
            Assert.Equal(newBookingId, response);
        }

        [Theory]
        [InlineData("2023-01-01 07:00", "2029-01-01 08:00")]
        [InlineData("2023-01-01 07:00", "2023-01-05 07:00")]
        public async Task CreateBooking_WhenDateTimesAreInThePast_ShouldThrow422(string dateFrom, string dateTo)
        {
            // Arrange
            var booking = new BookingEntity
            {
                DateFrom = DateTime.Parse(dateFrom),
                DateTo = DateTime.Parse(dateTo)
            };

            // Act
            var action = async () => await this.bookingService.CreateBooking(booking);

            // Assert
            var exception = await Assert.ThrowsAsync<UnprocessableEntityException>(action);
            Assert.Equal("At least 1 of the datetimes provided are in the past.", exception.Message);
        }

        [Theory]
        [InlineData("2030-01-01 02:00", "2030-01-01 01:00")]
        [InlineData("2030-01-01 01:00", "2030-01-01 01:00")]
        public async Task CreateBooking_WhenDateToIsBeforeOrEqualToDateFrom_ShouldThrow422(string dateFrom, string dateTo)
        {
            // Arrange
            var booking = new BookingEntity
            {
                DateFrom = DateTime.Parse(dateFrom),
                DateTo = DateTime.Parse(dateTo)
            };

            // Act
            var action = async () => await this.bookingService.CreateBooking(booking);

            // Assert
            var exception = await Assert.ThrowsAsync<UnprocessableEntityException>(action);
            Assert.Equal("DateTo must be after DateFrom.", exception.Message);
        }

        [Fact]
        public async Task CreateBooking_WhenThereAreNoParkingSpaces_ShouldThrow422()
        {
            // Arrange
            var booking = new BookingEntity
            {
                DateFrom = DateTime.Parse("2030-01-01 07:00"),
                DateTo = DateTime.Parse("2030-01-02 07:00")
            };

            var maxBookings = new List<BookingEntity>(new BookingEntity[Constants.ParkingMaxCapacity]);

            this.bookingRepositoryMock.Setup(x => x.GetAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                                      .ReturnsAsync(maxBookings);

            // Act
            var action = async () => await this.bookingService.CreateBooking(booking);

            // Assert
            var exception = await Assert.ThrowsAsync<UnprocessableEntityException>(action);
            Assert.Equal("There are no available parking spaces between 01/01/2030 07:00:00 and 02/01/2030 07:00:00", exception.Message);
        }

        [Theory]
        [InlineData("2030-01-01 07:00", "2030-01-05 07:00", 2950)] // weekday/weekend mix - winter
        [InlineData("2030-01-06 07:00", "2030-01-08 07:00", 1850)] // weekend/weekday mix - summer
        [InlineData("2030-06-01 07:00", "2030-06-02 07:00", 4500)] // weekend - summer
        public async Task CreateBooking_WhenItsOverWeekdaysAndWeekends_CorrectPriceIsSet(string dateFrom, string dateTo, int totalPrice)
        {
            // Arrange
            var bookings = new List<BookingEntity>();
            this.bookingRepositoryMock.Setup(x => x.GetAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                                      .ReturnsAsync(bookings);

            int calculatedPrice = 0;
            this.bookingRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<BookingTable>()))
                                      .Callback<BookingTable>(r => calculatedPrice = r.Price);

            var booking = new BookingEntity
            {
                DateFrom = DateTime.Parse(dateFrom),
                DateTo = DateTime.Parse(dateTo),
            };

            // Act
            var response = await this.bookingService.CreateBooking(booking);

            // Assert
            Assert.Equal(totalPrice, calculatedPrice);
        }
    }
}