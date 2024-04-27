using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankAccount.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<BankAccount.Core.Entities.Account> Accounts { get; set; } = null!;
    public DbSet<BankAccount.Core.Entities.Transaction> Transactions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountMap());
        modelBuilder.ApplyConfiguration(new TransactionMap());
    }
    
}