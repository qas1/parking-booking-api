using Microsoft.AspNetCore.Mvc;
using ParkingBookingAPI.Core.Entities;
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

        public BookingEntity ToDomainEntity()
        {
            return new BookingEntity
            {
                Id = this.Id.Value,
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
                Name = this.Name
            };
        }
    }
}
