using Microsoft.EntityFrameworkCore;

namespace MiniApi.Models;

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(o => new {o.FirstName, o.LastName});
        modelBuilder.Entity<Order>().HasKey(o => new {o.Region, o.Portfolio});
    }
}