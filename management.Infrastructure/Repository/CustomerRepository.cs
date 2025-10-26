using management.Domain.Models;
using management.Infrastructure.Interfaces;

namespace management.Infrastructure.Repository;

public class CustomerRepository : ICustomerRepository
{
private readonly List<Customer> _customers = new();
private int _nextId = 1;

public IEnumerable<Customer> GetAll()
{
    return _customers;
}

public Customer? GetById(int id)
{
    return _customers.FirstOrDefault(c => c.Id == id);
}

public Customer Add(Customer customer)
{
    customer.Id = _nextId++;
    _customers.Add(customer);
    return customer;
}

public void Update(Customer customer)
{
    var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
    if (existing != null)
    {
        existing.Name = customer.Name;
        existing.Email = customer.Email;
    }
}

public void Delete(int id)
{
    var existing = _customers.FirstOrDefault(c => c.Id == id);
    if (existing != null)
    {
        _customers.Remove(existing);
    }
}
}
