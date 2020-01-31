using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    class Account
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }       
        public int NumberOfBooks { get; }
        public DateTime CreatedDate { get; set; }
        public string EmailAddress { get; set; }

        public int Borrow(int amount)
        {
            NumberOfBooks += amount;
            return NumberOfBooks;
        }

        public int Return(int amount)
        {
            NumberOfBooks -= amount;
            return NumberOfBooks;
        }
        
    }


}
