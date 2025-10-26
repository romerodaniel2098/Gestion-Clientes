using management.Domain.Models;
using management.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace management.Application.Services
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Obtener todas las órdenes
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer) // ✅ Solo incluimos Customer, ya que OrderDetails no existe aún
                .ToListAsync();
        }

        // 🔹 Obtener una orden por su ID
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        // 🔹 Crear una nueva orden
        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // 🔹 Actualizar una orden existente
        public async Task<bool> UpdateAsync(int id, Order updated)
        {
            var existing = await _context.Orders.FindAsync(id);
            if (existing == null) return false;
            
            existing.OrderDate = updated.OrderDate;
            existing.CustomerId = updated.CustomerId;

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
