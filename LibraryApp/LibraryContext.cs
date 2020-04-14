using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    class LibraryContext: DbContext 
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = LibraryDb; Integrated Security = True; Connect Timeout = 30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Accounts");

                e.HasKey(a => a.AccountNumber)
                    .HasName("PK_Accounts");

                e.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                e.Property(a => a.EmailAddress)
                    .HasMaxLength(100)
                    .IsRequired();

                e.Property(a => a.Balance)
                    .IsRequired();

                e.Property(a => a.AccountType)
                    .IsRequired();

                e.Property(a => a.AccountName)
                    .HasMaxLength(100)
                    .IsRequired();


            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transactions");
                e.HasKey(t => t.TransactionId)
                    .HasName("PK_Transactions");

                e.Property(t => t.TransactionId)
                    .ValueGeneratedOnAdd();
                e.Property(t => t.TransactionType)
                    .IsRequired();
                e.Property(t => t.Amount)
                    .IsRequired();

                e.Property(t => t.TransactionDate)
                    .IsRequired();

                e.HasOne(t => t.Account)
                    .WithMany()
                    .HasForeignKey(t => t.AccountNumber);
            });

        }
    }
}
