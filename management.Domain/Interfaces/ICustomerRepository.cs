using management.Domain.Models;

namespace management.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    IEnumerable<Customer> GetAll();
    Customer? GetById(int id);
    Customer Add(Customer customer);
    void Update(Customer customer);
    void Delete(int id);
}