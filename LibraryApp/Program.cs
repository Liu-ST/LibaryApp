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
                        try
                        {
                            Console.Write("Account name: ");
                            var accountName = Console.ReadLine();
                            //if (string.IsNullOrEmpty(accountName))
                            //{
                            //    throw new ArgumentNullException("accountName", "Account name is required!");
                            //}
                            Console.Write("Email Address: ");
                            var emailAddress = Console.ReadLine();
                            //if (string.IsNullOrEmpty(emailAddress))
                            //{
                            //    throw new ArgumentNullException("Email address", "Email address is required!");
                            //}
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
                        }
                        catch(ArgumentNullException ax)
                        {
                            Console.WriteLine($"Error - {ax.Message}");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Error-{ax.Message}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Amount number is required!");
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong! Please try again!");
                        }
                            
                        break;

                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to borrow:");
                        var borrowAmount = Convert.ToInt32(Console.ReadLine());
                        Library.Borrow(accountNumber, borrowAmount);
                        Console.WriteLine("Borrow completed successfully!");
                        break;

                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to return:");
                        var returnAmount = Convert.ToInt32(Console.ReadLine());
                        Library.Borrow(accountNumber, returnAmount);
                        Console.WriteLine("Return completed successfully!");
                        break;

                    case "4":
                        PrintAllAccounts();
                        break;

                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Library.GetTransactionsByAccountNumber(accountNumber);
                        foreach(var transaction in transactions)
                        {
                            Console.WriteLine($"TT:{transaction.TransactionType}, TD:{transaction.TransactionDate}, TA:{transaction.Amount}, AN:{transaction.AccountNumber}, D:{transaction.Description}");
                        }
                        break;
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
