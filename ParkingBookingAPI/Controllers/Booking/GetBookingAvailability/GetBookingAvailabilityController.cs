using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Entities;
using ParkingBookingAPI.Services.Booking;

namespace ParkingBookingAPI.Controllers.Booking.GetBookingAvailability
{
    [ApiController]
    public class GetBookingAvailabilityController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public GetBookingAvailabilityController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [AllowAnonymous]
        [HttpGet("api/bookings/check-availability")]
        public async Task<ActionResult<AvailabilityEntity>> Get([FromQuery] GetBookingAvailabilityRequestModel request)
        {
            var availabilityEntity = await this.bookingService.GetBookingAvailability(request.ToDomainEntity());

            return Ok(availabilityEntity);
        }
    }
}
