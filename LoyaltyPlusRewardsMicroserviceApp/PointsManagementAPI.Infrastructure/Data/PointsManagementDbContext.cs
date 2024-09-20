using Microsoft.EntityFrameworkCore;
using PointsAPI.Core.Entities;

namespace PointsAPI.Infrastructure.Data;

public class PointsManagementDbContext: DbContext
{
    public PointsManagementDbContext(DbContextOptions<PointsManagementDbContext> options): base(options)
    {
        
    }
    
    public DbSet<PointsTransaction> PointsTransactions { get; set; }
    public DbSet<PointsBalance> PointsBalances { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //Customer
        modelBuilder.Entity<Customer>().HasKey(p => p.Id);
        modelBuilder.Entity<Customer>().Property(pb => pb.Id).ValueGeneratedNever();
        
        //PointsBalance
        modelBuilder.Entity<PointsBalance>().HasKey(p => p.CustomerId);
        modelBuilder.Entity<PointsBalance>()
            .HasOne(pb => pb.Customer)
            .WithOne() 
            .HasForeignKey<PointsBalance>(pb => pb.CustomerId) 
            .OnDelete(DeleteBehavior.Cascade); 
        
        
        modelBuilder.Entity<Customer>().HasIndex(p => p.Email).IsUnique();
        modelBuilder.Entity<PointsTransaction>().HasKey(p => p.TransactionId);
        modelBuilder.Entity<PointsTransaction>().Property(pb => pb.TransactionId).ValueGeneratedNever();

    }
}