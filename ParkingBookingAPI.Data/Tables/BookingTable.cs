using ParkingBookingAPI.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingBookingAPI.Data.Tables
{
    [Table("Bookings")]
    public class BookingTable
    {
        public Guid Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public static BookingTable FromEntity(BookingEntity entity)
        {
            return new BookingTable
            {
                Id = entity.Id,
                DateFrom = entity.DateFrom,
                DateTo = entity.DateTo,
                Name = entity.Name,
                Price = entity.Price,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
