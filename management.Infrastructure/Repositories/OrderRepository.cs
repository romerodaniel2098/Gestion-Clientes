using management.Domain.Models;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Repositories
{
    public class OrderRepository
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
        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // 🔹 Actualizar una orden
        public async Task<bool> UpdateAsync(Order order)
        {
            var existing = await _context.Orders.FindAsync(order.Id);
            if (existing == null) return false;

            existing.OrderDate = order.OrderDate;
            existing.CustomerId = order.CustomerId;

            _context.Orders.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // 🔹 Eliminar una orden
        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}