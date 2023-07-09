using Microsoft.AspNetCore.Mvc;

namespace ParkingBookingApi.Controllers.Booking.CreateBooking
{
    [ApiController]
    public class CreateBookingController : ControllerBase
    {
        [HttpPost("api/bookings")]
        public Task Post(CreateBookingRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
