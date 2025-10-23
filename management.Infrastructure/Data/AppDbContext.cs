using management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Data;

public class AppDbContext : DbContext
{
    //DbSets
    public DbSet<Customer> customers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    //Here we are going to put our model's config 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Customer>()
        //     .HasMany(c => c.Orders)
        //     .WithOne(r => r.customers)
        //     .HasForeignKey(r => r.CustomersId);
        
        // === Primary Keys ===
        
        // === Relation Ships ===
        
    }
}