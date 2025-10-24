
using management.Domain.Models;
using management.Infrastructure.Interfaces;

namespace management.Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetAllClients()
        {
            return _repository.GetAll();
        }

        public Customer? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Customer Add(Customer customer)
        {
            return _repository.Add(customer);
        }

        public void Edit(Customer customer)
        {
            _repository.Update(customer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}

