using CustomerRegistrationAndAuthAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistrationAndAuthAPI.Infrastructure.Data;

public class CustomerRegistrationAndAuthDbContext: DbContext
{
    public CustomerRegistrationAndAuthDbContext(DbContextOptions<CustomerRegistrationAndAuthDbContext> options) :
        base(options)
    {
        
    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerRole> CustomerRoles { get; set; }
    public DbSet<LoginAttempt> LoginAttempts { get; set; }
    public DbSet<Role> Roles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerRole>().HasKey(e => new { e.RoleId, e.CustomerId });
        modelBuilder.Entity<Customer>().HasIndex(p => p.Email).IsUnique();
        modelBuilder.Entity<Role>().HasIndex(p => p.RoleName).IsUnique();
    }
}