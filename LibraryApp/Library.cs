using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp
{
    static class Library
    {
        private static LibraryContext db = new LibraryContext();
        /// <summary>
        /// Create a library account
        /// </summary>
        /// <param name="accountName">name</param>
        /// <param name="emailAddress">email</param>
        /// <param name="accountType">type of your account</param>
        /// <param name="initialBorrowNumber">initial number </param>
        /// <returns>Newly created account</returns>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        public static Account CreateAccount(string accountName, string emailAddress, TypeOfAccounts accountType = TypeOfAccounts.OneDay, int initialBorrowNumber = 0)
        {
            if(string.IsNullOrEmpty(accountName)|| string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentException("Account name and Email Address are required!");
            }
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };
                        
            db.Accounts.Add(account);
            db.SaveChanges();

            if (initialBorrowNumber > 0)
            {
                Borrow(account.AccountNumber, initialBorrowNumber);
            }

            return account;
        }

        public static IEnumerable<Account> GetAccountsByEmailAddress(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static void Borrow(int accountNumber, int amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw exception
                return;
            }
            account.Borrow(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TransactionType = TypeOfTransactions.Borrow,
                Description = "Borrow book",
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static void Return(int accountNumber, int amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                //throw exception
                return;
            }
            account.Return(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TransactionType = TypeOfTransactions.Return,
                Description = "Return book",
                Amount = amount,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }
    }
}
