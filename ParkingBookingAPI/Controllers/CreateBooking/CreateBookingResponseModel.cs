namespace ParkingBookingAPI.Controllers.CreateBooking
{
    public class CreateBookingResponseModel
    {
        public Guid Id { get; set; }

        public CreateBookingResponseModel(Guid id)
        {
            this.Id = id;
        }
    }
}
