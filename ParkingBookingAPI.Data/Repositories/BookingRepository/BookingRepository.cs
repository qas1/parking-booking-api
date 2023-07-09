using Microsoft.EntityFrameworkCore;
using ParkingBookingAPI.Core.Entities;
using ParkingBookingAPI.Data;
using ParkingBookingAPI.Data.Tables;

namespace ParkingBookingApi.Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext dataContext;

        public BookingRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Guid> CreateAsync(BookingTable booking)
        {
            booking.CreatedAt = DateTime.Now;

            this.dataContext.Bookings.Add(booking);
            await dataContext.SaveChangesAsync();

            return booking.Id;
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookingEntity>> GetAsync(DateTime dateFrom, DateTime dateTo)
        {
            var data = await dataContext.Bookings
                .Where(x => x.DateFrom >= dateFrom && x.DateFrom < dateTo ||
                            x.DateFrom <= dateFrom && x.DateTo < dateTo ||
                            x.DateFrom <= dateFrom && x.DateTo > dateTo ||
                            x.DateFrom >= dateFrom && x.DateTo > dateTo ||
                            x.DateFrom >= dateFrom && x.DateTo == dateTo)
                .ToListAsync();

            var entities = data.Select(x => new BookingEntity()
            {
                Id = x.Id,
                DateFrom = x.DateFrom,
                DateTo = x.DateTo,
                CreatedAt = x.CreatedAt,
                Name = x.Name,
                Price = x.Price,
                UpdatedAt = x.UpdatedAt
            }).ToList();

            return entities;
        }

        public Task<BookingEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BookingTable> UpdateAsync(BookingTable bookingsTable)
        {
            throw new NotImplementedException();
        }
    }
}
