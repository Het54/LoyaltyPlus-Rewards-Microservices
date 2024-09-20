using Microsoft.EntityFrameworkCore;
using TransactionHistoryAPI.Core.Entities;

namespace TransactionHistoryAPI.Infrastructure.Data;

public class TransactionDbContext: DbContext
{
    public TransactionDbContext(DbContextOptions<TransactionDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    
}