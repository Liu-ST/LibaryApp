using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryApp
{
    static class Library
    {
        private static List<Account> accounts = new List<Account>();
        /// <summary>
        /// Create a library account
        /// </summary>
        /// <param name="accountName">name</param>
        /// <param name="emailAddress">email</param>
        /// <param name="accountType">type of your account</param>
        /// <param name="initialBorrowNumber">initial number </param>
        /// <returns>Newly created account</returns>
        public static Account CreateAccount(string accountName, string emailAddress, TypeOfAccounts accountType=TypeOfAccounts.OneDay, int initialBorrowNumber=0)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if (initialBorrowNumber > 0)
            {
                account.Borrow(initialBorrowNumber);
            }

            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> GetAccountsByEmailAddress(string emailAddress)
        {
            return accounts.Where(a => a.EmailAddress == emailAddress); 
        }
         
    }
}
