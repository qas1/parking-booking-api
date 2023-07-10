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

        public async Task DeleteAsync(Guid id)
        {
            var booking = this.dataContext.Bookings.Single(x => x.Id == id);

            this.dataContext.Remove(booking);

            await dataContext.SaveChangesAsync();
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

        public async Task<BookingEntity?> GetByIdAsync(Guid id)
        {
            var record = await dataContext.Bookings
                .Where(record => record.Id == id)
                .FirstOrDefaultAsync();

            if (record == null)
            {
                return null;
            }

            var entity = new BookingEntity
            {
                Id = record.Id,
                Name = record.Name,
                DateFrom = record.DateFrom,
                DateTo = record.DateTo,
                Price = record.Price,
                CreatedAt = record.CreatedAt,
                UpdatedAt = record.UpdatedAt
            };

            return entity;
        }

        public async Task<BookingEntity> UpdateAsync(BookingTable table)
        {
            table.UpdatedAt = DateTime.Now;

            dataContext.Bookings.Update(table);
            await dataContext.SaveChangesAsync();

            var entity = new BookingEntity
            {
                Id = table.Id,
                Name = table.Name,
                DateFrom = table.DateFrom,
                DateTo = table.DateTo,
                Price = table.Price,
                CreatedAt = table.CreatedAt,
                UpdatedAt = table.UpdatedAt
            };

            return entity;
        }
    }
}
