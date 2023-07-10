using Microsoft.AspNetCore.Mvc;
using ParkingBookingApi.Services.Booking;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingApi.Controllers.Booking.UpdateBooking
{
    [ApiController]
    public class UpdateBookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public UpdateBookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPut("api/bookings/{id}")]
        public async Task<ActionResult<BookingTable>> Put(UpdateBookingRequestModel request)
        {
            var entity = await this.bookingService.UpdateBooking(request.ToDomainEntity());

            return Ok(entity);
        }
    }
}
