using Microsoft.AspNetCore.Mvc;
using ParkingBookingApi.Services.Booking;

namespace ParkingBookingApi.Controllers.Booking.DeleteBooking
{
    [ApiController]
    public class DeleteBookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public DeleteBookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpDelete("api/bookings/{id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteBookingRequestModel request)
        {
            await this.bookingService.DeleteBooking(request.Id);

            return NoContent();
        }
    }
}
