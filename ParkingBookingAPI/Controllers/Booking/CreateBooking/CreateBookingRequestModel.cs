using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingAPI.Controllers.Booking.CreateBooking
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

        public BookingEntity ToDomainEntity()
        {
            return new BookingEntity
            {
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
                Name = this.Name
            };
        }
    }
}
