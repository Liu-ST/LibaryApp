using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var myAccount = Library.CreateAccount("Shitian's Library Account", "test@test.com", TypeofAccounts.OneMonth, 5);
            //Console.WriteLine($"AN:{myAccount.AccountNumber}, AccountName:{myAccount.AccountName}, B:{myAccount.Balance}, CD:{myAccount.CreatedDate}, AT:{myAccount.AccountType}");

            Console.WriteLine("************************************");
            Console.WriteLine("Welcome to my Library!");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Borrow");
            Console.WriteLine("3. Return");
            Console.WriteLine("4. Print all accounts");
            Console.WriteLine("5. Print all history");

            Console.Write("Please select an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    Console.WriteLine("Thanks for using the Library!");
                    return;
                case "1":
                    Console.Write("Account name: ");
                    var accountName = Console.ReadLine();
                    Console.Write("Email Address: ");
                    var emailAddress = Console.ReadLine();
                    Console.Write("Initial number of books to borrow: ");
                    var amount = Convert.ToInt32(Console.ReadLine());
                    var myAccount = Library.CreateAccount(accountName, emailAddress);
                    Console.WriteLine($"AN:{myAccount.AccountNumber}, AccountName:{myAccount.AccountName}, B:{myAccount.Balance}, CD:{myAccount.CreatedDate}, AT:{myAccount.AccountType}");
                    break;
                case "2":
                case "3":
                case "4":
                case "5":
                default:
                    Console.WriteLine("Invalid option - try again!");
                    break;
                    


            }
        }
    }
}
