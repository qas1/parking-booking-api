﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Services.Booking;

namespace ParkingBookingAPI.Controllers.Booking.DeleteBooking
{
    [ApiController]
    public class DeleteBookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public DeleteBookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [Authorize]
        [HttpDelete("api/bookings/{id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteBookingRequestModel request)
        {
            await this.bookingService.DeleteBooking(request.Id);

            return NoContent();
        }
    }
}
