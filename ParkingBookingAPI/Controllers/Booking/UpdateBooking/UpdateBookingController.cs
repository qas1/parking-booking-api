using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Services.Booking;
using ParkingBookingAPI.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingAPI.Controllers.Booking.UpdateBooking
{
    [ApiController]
    public class UpdateBookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public UpdateBookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [Authorize]
        [HttpPut("api/bookings/{id}")]
        public async Task<ActionResult<BookingTable>> Put(UpdateBookingRequestModel request, [FromRoute] [Required] Guid id)
        {
            var entity = await this.bookingService.UpdateBooking(request.ToDomainEntity(id));

            return Ok(entity);
        }
    }
}
