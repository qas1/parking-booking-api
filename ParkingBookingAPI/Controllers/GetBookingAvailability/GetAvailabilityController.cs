using Microsoft.AspNetCore.Mvc;
using ParkingBookingApi.Controllers.Booking.GetAvailability;

namespace ParkingBookingApi.Controllers.Booking.DeleteBooking
{
    [ApiController]
    public class GetBookingAvailabilityController : ControllerBase
    {
        [HttpGet("api/bookings/check-availability")]
        public Task Get([FromQuery] GetAvailabilityRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
