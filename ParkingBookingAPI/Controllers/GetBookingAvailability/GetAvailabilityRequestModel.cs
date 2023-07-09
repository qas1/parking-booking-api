using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingApi.Controllers.Booking.GetAvailability
{
    public class GetAvailabilityRequestModel
    {
        [Required]
        [FromQuery(Name = "DateFrom")]
        public DateTime? DateFrom { get; set; }

        [Required]
        [FromQuery(Name = "DateTo")]
        public DateTime? DateTo { get; set; }
    }
}
