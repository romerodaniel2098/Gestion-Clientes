using management.Domain.Interfaces;
using management.Domain.Models;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Obtener todas las órdenes
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .ToListAsync();
        }

        // 🔹 Obtener una orden por ID
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        // 🔹 Crear una orden
        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // 🔹 Actualizar una orden
        public async Task<Order> UpdateAsync(int Id,Order order)
        {
            var existing = await _context.Orders.FindAsync(Id);
            if (existing == null) return null;

            existing.OrderDate = order.OrderDate;
            existing.CustomerId = order.CustomerId;

            _context.Orders.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        // 🔹 Eliminar una orden
        public async Task<bool?> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}