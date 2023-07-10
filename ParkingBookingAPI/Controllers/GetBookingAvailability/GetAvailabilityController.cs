using Microsoft.AspNetCore.Mvc;
using ParkingBookingApi.Controllers.Booking.GetAvailability;
using ParkingBookingApi.Entities;
using ParkingBookingApi.Services.Booking;

namespace ParkingBookingApi.Controllers.Booking.DeleteBooking
{
    [ApiController]
    public class GetBookingAvailabilityController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public GetBookingAvailabilityController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet("api/bookings/check-availability")]
        public async Task<ActionResult<AvailabilityEntity>> Get([FromQuery] GetAvailabilityRequestModel request)
        {
            var availabilityEntity = await this.bookingService.GetBookingAvailability(request.ToDomainEntity());

            return Ok(availabilityEntity);
        }
    }
}
