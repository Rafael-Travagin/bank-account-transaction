using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Entities;
using BankAccount.Core.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Infra.Mappings;

public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<BankAccount.Core.Entities.Transaction> builder)
    {
        builder
            .ToTable("Transaction");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Type)
            .IsRequired()
            .HasColumnName("Type")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder
            .Property(x => x.Status)
            .IsRequired(true)
            .HasColumnName("Status")
            .HasColumnType("NVARCHAR")
            .HasDefaultValue(StatusTransaction.Active)
            .HasMaxLength(10);

        builder
            .OwnsOne(x => x.Amount)
            .Property(x => x.Value)
            .HasColumnName("Amount")
            .HasColumnType("Decimal")
            .HasDefaultValue(0)
            .IsRequired(true);

        builder
            .Property(x => x.Date)
            .IsRequired(true)
            .HasColumnName("Date")
            .HasColumnType("DateTime")
            .HasDefaultValue(DateTime.Now.ToUniversalTime());                

        builder 
            .HasOne(x => x.Account)
            .WithMany(x => x.Transactions)            
            .HasConstraintName("FK_Transactions_Account")
            .OnDelete(DeleteBehavior.Cascade);
        
    }
    
}