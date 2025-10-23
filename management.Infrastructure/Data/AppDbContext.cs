using Microsoft.EntityFrameworkCore;

namespace management.Infrastructure.Data;

public class AppDbContext : DbContext
{
    //DbSets
    
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

    //Here we are going to put our model's config 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // === Primary Keys ===
        
        // === Relation Ships ===
        
    }
}