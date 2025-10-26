using management.Domain.Interfaces;
using management.Domain.Models;

namespace management.Application.Services
{
    public class OrderDetailService
    {
        private readonly IRepository<OrderDetail> _repository;

        public OrderDetailService(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDetail>?> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<OrderDetail?> CreateAsync(OrderDetail detail)
            => await _repository.CreateAsync(detail);

        public async Task<OrderDetail?> UpdateAsync(int id, OrderDetail detail)
            => await _repository.UpdateAsync(id, detail);

        public async Task<bool?> DeleteAsync(int id)
            => await _repository.DeleteAsync(id);
    }
}