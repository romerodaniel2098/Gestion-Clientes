namespace management.Domain.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    public new List<Order> Orders { get; set; } = new List<Order>();
}