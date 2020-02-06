using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    static class Library
    {
        /// <summary>
        /// Create a library account
        /// </summary>
        /// <param name="accountName">name</param>
        /// <param name="emailAddress">email</param>
        /// <param name="accountType">type of your account</param>
        /// <param name="initialBorrowNumber">initial number </param>
        /// <returns>Newly created account</returns>
        public static Account CreateAccount(string accountName, string emailAddress, TypeofAccounts accountType=TypeofAccounts.OneDay, int initialBorrowNumber=0)
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

            return account;

        }
    }
}
