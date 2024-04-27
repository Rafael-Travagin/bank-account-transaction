using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Core.Entities;
using BankAccount.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccount.Infra.Mappings;

public class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .ToTable("Account");

        builder
            .HasKey(x => x.Id);

            builder
            .OwnsOne(x => x.Bank)
            .Property(x => x.Name)
            .HasColumnName("Bank")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60)
            .IsRequired();

            builder
            .OwnsOne(x => x.AccountName)
            .Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60)
            .IsRequired();

            builder
            .OwnsOne(x => x.Document)
            .Property(x => x.Value)
            .HasColumnName("Document")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(14)
            .IsRequired();
        
    }
    
}