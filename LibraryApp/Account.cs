using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    enum TypeofAccounts
    {
        OneDay,
        OneMonth,
        OneYear          
    }
    /// <summary>
    /// This class represents a library account
    /// where you can borrow and returen books from
    /// </summary>
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public int AccountNumber { get; private set; }
        public string AccountName { get; set; }
        public int Balance { get; private set; }
        public TypeofAccounts AccountType { get; set; }
        public DateTime CreatedDate { get; private set; }
        public string EmailAddress { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Add how many books you borrowed
        /// </summary>
        /// <param name="amount">Amount borrowed</param>
        /// <returns>New balance</returns>
        public int Borrow(int amount)
        {
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Minus how many books you returned
        /// </summary>
        /// <param name="amount">Amount to return</param>
        /// <returns>New balance</returns>
        public int Return(int amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion

        #region Constructor
        //Default constructor
        public Account()
        {
           AccountNumber = ++ lastAccountNumber;
            CreatedDate = DateTime.UtcNow;
        }

        #endregion

    }


}
