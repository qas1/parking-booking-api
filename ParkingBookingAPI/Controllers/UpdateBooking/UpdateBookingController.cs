using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ParkingBookingApi.Controllers.Booking.UpdateBooking
{
    [ApiController]
    public class UpdateBookingController : ControllerBase
    {
        [Authorize]
        [HttpPut("api/bookings/{id}")]
        public Task Put(UpdateBookingRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
