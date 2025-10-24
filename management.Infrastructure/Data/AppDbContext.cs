using management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> customers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
        modelBuilder.Entity<OrderDetail>()
            .Property(o => o.UnitPrice)
            .HasColumnType("decimal(10,2)");
    }
        
    }
