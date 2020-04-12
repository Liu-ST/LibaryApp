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
            modelBuilder.Entity<Account>(e => {
                e.ToTable("Accounts");

                e.HasKey(a => a.AccountNumber)
                    .HasName("PK_Accounts");

                e.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();

                e.Property(a => a.EmailAddress)
                    .HasMaxLength(100)
            })                    
        }
    }
}
