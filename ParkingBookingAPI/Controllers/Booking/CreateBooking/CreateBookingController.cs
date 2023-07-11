using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Services.Booking;

namespace ParkingBookingAPI.Controllers.Booking.CreateBooking
{
    [ApiController]
    public class CreateBookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public CreateBookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [Authorize]
        [HttpPost("api/bookings")]
        public async Task<ActionResult<CreateBookingResponseModel>> Post(CreateBookingRequestModel request)
        {
            var id = await this.bookingService.CreateBooking(request.ToDomainEntity());

            var response = new CreateBookingResponseModel(id);

            return Created("", response);
        }
    }
}
