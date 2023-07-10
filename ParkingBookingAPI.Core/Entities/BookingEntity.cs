namespace ParkingBookingAPI.Core.Entities
{
    public class BookingEntity : AuditableEntity
    {
        public Guid Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }

        public static BookingEntity CreateBookingEntity(
            Guid id,
            DateTime dateFrom,
            DateTime dateTo,
            string name,
            int price,
            DateTime createdAt,
            DateTime? updatedAt)
        {
            return new BookingEntity()
            {
                Id = id,
                DateFrom = dateFrom,
                DateTo = dateTo,
                Name = name,
                Price = price,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };
        }
    }
}
