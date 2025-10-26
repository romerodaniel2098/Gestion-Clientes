using management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Data;

public class AppDbContext : DbContext
{
    //DbSets
    public DbSet<Customer> customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    //Here we are going to put our model's config 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // === RELACIONES ===
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
        modelBuilder.Entity<OrderDetail>()
            .Property(o => o.UnitPrice)
            .HasColumnType("decimal(10,2)");
        
        // Un cliente puede tener muchos pedidos
        modelBuilder.Entity<Order>()
                    .HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId);
    }
}