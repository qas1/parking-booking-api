namespace ParkingBookingAPI.Core.Entities
{
    public class BookingEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }
    }
}
