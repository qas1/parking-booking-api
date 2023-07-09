using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingApi.Controllers.Booking.UpdateBooking
{
    public class UpdateBookingRequestModel
    {
        [Required]
        [FromRoute]
        public Guid? Id { get; set; }

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
