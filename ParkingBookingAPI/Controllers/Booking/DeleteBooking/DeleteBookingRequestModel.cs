using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingAPI.Controllers.Booking.DeleteBooking
{
    public class DeleteBookingRequestModel
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }
    }
}
