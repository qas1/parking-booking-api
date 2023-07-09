using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingApi.Controllers.Booking.CreateBooking
{
    public class CreateBookingRequestModel
    {
        [Required]
        [FromBody]
        public DateTime? DateFrom { get; set; }

        [Required]
        [FromBody]
        public DateTime? DateTo { get; set; }

        [Required]
        [FromBody]
        public string Name { get; set; } = string.Empty;
    }
}
