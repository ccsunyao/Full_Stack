using System;

namespace Exercise7
{
    class ATMTransaction
    {
        static void Main(string[] args)
        {
            int amount = 1000, deposit, withdraw;
            int choice, pin = 0, x = 0;
            Console.WriteLine("Enter Your Pin Number");
            pin = Convert.ToInt16(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("***********WELCOME TO YES BANK ATM SERVICE***********\n");
                Console.WriteLine("1. Check Balance\n");
                Console.WriteLine("2. Withdraw Cash\n");
                Console.WriteLine("3. Deposit Cash\n");
                Console.WriteLine("4. Quit \n");
                Console.WriteLine("*****************************************************\n");
                Console.WriteLine("ENTER YOUR CHOICE : ");
                choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n YOUR BALANCE IS Rs : {0} ", amount);
                        break;
                    case 2:
                        Console.WriteLine("\n ENTER THE WITHDRAW AMOUNT : ");
                        withdraw = Convert.ToInt16(Console.ReadLine());
                        if (withdraw > (amount - 1000))
                        {
                            Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
                        }
                        else
                        {
                            amount = amount - withdraw;
                            Console.WriteLine("\n CURRENT BALANCE IS Rs : {0}", amount);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                        deposit = Convert.ToInt16(Console.ReadLine());
                        amount = amount + deposit;
                        Console.WriteLine("YOUR TOTAL BALANCE IS Rs : {0}", amount);
                        break;
                    case 4:
                        Console.WriteLine("\n THANK YOU!");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
