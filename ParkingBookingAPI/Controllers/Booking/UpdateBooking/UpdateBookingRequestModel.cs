using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingBookingApi.Controllers.Booking.UpdateBooking
{
    public class UpdateBookingRequestModel
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

        public BookingEntity ToDomainEntity(Guid id)
        {
            return new BookingEntity
            {
                Id = id,
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
                Name = this.Name
            };
        }
    }
}
