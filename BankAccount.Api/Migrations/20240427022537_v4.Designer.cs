﻿// <auto-generated />
using System;
using BankAccount.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankAccount.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240427022537_v4")]
    partial class v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankAccount.Core.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BankAccount.Core.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DateTime")
                        .HasDefaultValue(new DateTime(2024, 4, 27, 2, 25, 37, 327, DateTimeKind.Utc).AddTicks(3728))
                        .HasColumnName("Date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasDefaultValue("Active")
                        .HasColumnName("Status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("BankAccount.Core.Entities.Account", b =>
                {
                    b.OwnsOne("BankAccount.Core.ValueObjects.AccountName", "AccountName", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Name");

                            b1.HasKey("AccountId");

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsOne("BankAccount.Core.ValueObjects.Bank", "Bank", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Bank");

                            b1.HasKey("AccountId");

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsOne("BankAccount.Core.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Document");

                            b1.HasKey("AccountId");

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("AccountName")
                        .IsRequired();

                    b.Navigation("Bank")
                        .IsRequired();

                    b.Navigation("Document")
                        .IsRequired();
                });

            modelBuilder.Entity("BankAccount.Core.Entities.Transaction", b =>
                {
                    b.HasOne("BankAccount.Core.Entities.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Transactions_Account");

                    b.OwnsOne("BankAccount.Core.ValueObjects.Amount", "Amount", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("Decimal")
                                .HasDefaultValue(0m)
                                .HasColumnName("Amount");

                            b1.HasKey("TransactionId");

                            b1.ToTable("Transaction");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Amount")
                        .IsRequired();
                });

            modelBuilder.Entity("BankAccount.Core.Entities.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}