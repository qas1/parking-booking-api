using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingAPI.Controllers.Booking.GetAvailability
{
    public class GetAvailabilityRequestModel
    {
        [Required]
        [FromQuery(Name = "DateFrom")]
        public DateTime? DateFrom { get; set; }

        [Required]
        [FromQuery(Name = "DateTo")]
        public DateTime? DateTo { get; set; }

        public BookingEntity ToDomainEntity()
        {
            return new BookingEntity
            {
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
            };
        }
    }
}
