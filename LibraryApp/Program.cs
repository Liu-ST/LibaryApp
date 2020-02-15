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
            Console.WriteLine("************************************");

            while(true)
            { 
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

                        Console.WriteLine("Account type: ");
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        Console.Write("Select an option: ");
                        var accountType = Enum.Parse<TypeOfAccounts>(Console.ReadLine());

                        var myAccount = Library.CreateAccount(accountName, emailAddress, accountType, amount);
                        Console.WriteLine($"AN:{myAccount.AccountNumber},email Address:{myAccount.EmailAddress}, AccountName:{myAccount.AccountName}, B:{myAccount.Balance}, CD:{myAccount.CreatedDate}, AT:{myAccount.AccountType}");
                        break;
                    case "2":
                    case "3":
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                    default:
                        Console.WriteLine("Invalid option - try again!");
                        break;
                }
                    


            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var email = Console.ReadLine();

            var accounts = Library.GetAccountsByEmailAddress(email);
            foreach (var a in accounts)
            {
                Console.WriteLine($"AN:{a.AccountNumber},email Address:{a.EmailAddress}, AccountName:{a.AccountName}, B:{a.Balance}, CD:{a.CreatedDate}, AT:{a.AccountType}");
            }
        }
    }
}
