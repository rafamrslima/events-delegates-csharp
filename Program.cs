using System;

namespace MySolution
{
    public delegate void myEventHandler(decimal moneyDeposited);

    class Bank
    {
        public decimal MoneySaved { get; set; }
        public decimal TotalGoal { get; set; } = 500M;
        public event myEventHandler MoneySavedChanged;

        public int MoneyDeposited
        {
            set
            {
                this.MoneySavedChanged(value);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Bank bankAccount = new Bank();
 
            void putMoneyDelegate(decimal value)
            {
                bankAccount.MoneySaved += value;
            }

            bankAccount.MoneySavedChanged += putMoneyDelegate;

            //Using lambdas
            //bankAccount.MoneySavedChanged += (value) => bankAccount.MoneySaved += value;

            do
            {
                Console.WriteLine("How much to deposit?");
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    bankAccount.MoneyDeposited = Convert.ToInt32(str);

                    if (bankAccount.MoneySaved >= bankAccount.TotalGoal)
                        Console.WriteLine($"You reached your savings goal! You have {bankAccount.MoneySaved}");
                    else
                        Console.WriteLine($"The balance amount is {bankAccount.MoneySaved}");

                }
            } while (!str.Equals("exit"));

            Console.WriteLine("Goodbye!");
        }
    }
}
