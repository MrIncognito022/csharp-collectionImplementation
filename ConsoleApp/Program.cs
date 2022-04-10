// See https://aka.ms/new-console-template for more information
using Handlers;
using Models;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BankAccountHandler bankAccountHandler = new BankAccountHandler(100);

            IBankAccountHandler bankAccountHandler = new BankAccountCollectionHandler();
            
            //IBankAccountHandler bankAccountHandler = new BankAccountHandler(100);

            string title,accountType,code,toCode;
            decimal amount;
            bool choice = true;
            do
            {
                Console.Clear();
                Console.WriteLine("\t               ***** Enter your choice *****");
                Console.WriteLine("\t1...................Create a new Account......................");
                Console.WriteLine("\t2...................Search an Existing Account ...............");
                Console.WriteLine("\t3...................Deposit amount into the account...........");
                Console.WriteLine("\t4...................Withdraw amount from account..............");
                Console.WriteLine("\t5...................Transfer amount to other account");
                string? option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Account Title");
                            title = Console.ReadLine().Trim();
                            Console.WriteLine("Select the account type. 1) Saving 2) Current");
                            accountType = Console.ReadLine().Trim();

                            if (accountType == "1")
                            {
                                bankAccountHandler.Add(new SavingBankAccount()
                                {
                                    Title = title 
                                });
                            }
                            else if (accountType == "2")
                            {
                                bankAccountHandler.Add(new CurrentBankAccount()
                                { 
                                    Title = title 
                                }
                                );
                            }
                            Console.WriteLine("Account created");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Your Account Number");
                            code = Console.ReadLine().Trim();
                            BankAccount bankaccount = bankAccountHandler.GetBankAccount(code, false);
                            Console.WriteLine(bankaccount.ToString());
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the account number");
                            code = Console.ReadLine().Trim();
                            Console.WriteLine("Enter the amount to deposit");
                            amount = decimal.Parse(Console.ReadLine());
                            BankAccount bankAccount = bankAccountHandler.GetBankAccount(code);

                            if (bankAccount.PayIn(amount) == true)
                            {
                                Console.WriteLine("Amount deposit successfully");
                            }
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            
                        }
                        break;
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the account number");
                            code = Console.ReadLine().Trim();
                            Console.WriteLine("Enter the amount to Withdraw");
                            amount = decimal.Parse(Console.ReadLine());
                            BankAccount bankAccount = bankAccountHandler.GetBankAccount(code);
                            bankAccount.WithDraw(amount);
                            Console.WriteLine("Amount Withdraw successfully");
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                        }
                        break;
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter  from Transfer account number");
                            code = Console.ReadLine().Trim();
                            BankAccount fromBankAccount = bankAccountHandler.GetBankAccount(code);
                            Console.WriteLine("Enter to Transfer account number");
                            toCode = Console.ReadLine().Trim();
                            BankAccount toBankAccount = bankAccountHandler.GetBankAccount(toCode);
                            Console.WriteLine("Enter amount to transfer");
                            amount = decimal.Parse(Console.ReadLine());
                            if (fromBankAccount.Transfer(toBankAccount, amount)== true)
                            {
                                Console.WriteLine("Amount transfer successfully");
                                Console.WriteLine("Enter any Key");
                                Console.ReadKey();
                            }
                        }
                        break;
                        case "6":
                        {
                            Console.Clear();
                            BankAccount[] bankAccounts = bankAccountHandler.GetBankAccounts();
                            foreach(BankAccount bankAccount in bankAccounts)
                            {
                                Console.WriteLine(bankAccount.ToString());
                            }
                            Console.WriteLine("Press Any Key");
                            Console.ReadLine();
                        }

                        break ;
                    default:
                        choice = false;
                        break;
                }
            }
            while (choice);





        }
    }
}
