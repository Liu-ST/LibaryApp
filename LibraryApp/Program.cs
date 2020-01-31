using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAccount = new Account();
            myAccount.AccountName = "Shitian's Library Account";
            myAccount.AccountType = TypeofAccounts.OneMonth;
            myAccount.Borrow(5);
            Console.WriteLine($"AN:{myAccount.AccountNumber}, AccountName:{myAccount.AccountName}, B:{myAccount.Balance}, CD:{myAccount.CreatedDate}");

            var myAccount2 = new Account();
            myAccount2.AccountName = "Kal's library Account";
            myAccount2.AccountType = TypeofAccounts.OneYear;
            myAccount2.Borrow(10);
            Console.WriteLine($"AN:{myAccount2.AccountNumber}, AccountName:{myAccount2.AccountName}, B:{myAccount2.Balance}, CD:{myAccount2.CreatedDate}");

        }
    }
}
