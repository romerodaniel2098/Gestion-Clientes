using management.Domain.Models;
using management.Domain.Interfaces;

namespace management.Application.Services
{
    public class OrderService
    {
     
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        // 🔹 Obtener todas las órdenes
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // 🔹 Obtener una orden por su ID
        // public async Task<Order?> GetByIdAsync(int id)
        // {
        //     
        // }

        // 🔹 Crear una nueva orden
        public async Task<Order> CreateAsync(Order order)
        {
            return await _repository.CreateAsync(order);
        }

        // 🔹 Actualizar una orden existente
        public async Task<Order> UpdateAsync(int id, Order updated)
        {
            return await _repository.UpdateAsync(id, updated);
        }

        // 🔹 Eliminar una orden
        public async Task<bool?> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
