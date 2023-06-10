using System;
using Zhdannov_hw9;

public class Program
{
    public static void Main(string[] args)
    {
        ATM atm = new ATM(1000);
            ATMClient client = new ATMClient(atm);

            client.InsertCard("1234567890", 500);
            client.ViewBalance();

            client.Withdraw(200);
            client.ViewBalance();

            client.TopUp(100);
            client.ViewBalance();

            Console.ReadLine();
        
    }
}