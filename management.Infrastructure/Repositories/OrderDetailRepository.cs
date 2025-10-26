using management.Domain.Interfaces;
using management.Domain.Models;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositories
{
    public class OrderDetailRepository : IRepository<OrderDetail>
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>?> GetAllAsync()
            => await _context.OrderDetails.AsNoTracking().ToListAsync();

        public async Task<OrderDetail?> CreateAsync(OrderDetail entity)
        {
            _context.OrderDetails.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrderDetail?> UpdateAsync(int id, OrderDetail entity)
        {
            var existing = await _context.OrderDetails.FindAsync(id);
            if (existing == null) return null;

            existing.ProductName = entity.ProductName;
            existing.Quantity = entity.Quantity;
            existing.UnitPrice = entity.UnitPrice;
            existing.OrderId = entity.OrderId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            var existing = await _context.OrderDetails.FindAsync(id);
            if (existing == null) return false;

            _context.OrderDetails.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}