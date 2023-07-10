using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingApi.Controllers.Booking.DeleteBooking
{
    public class DeleteBookingRequestModel
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }
    }
}
