using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ParkingBookingApi.Controllers.Booking.DeleteBooking
{
    [ApiController]
    public class DeleteBookingController : ControllerBase
    {
        [Authorize]
        [HttpDelete("api/bookings/{id}")]
        public Task Delete([FromRoute] DeleteBookingRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
