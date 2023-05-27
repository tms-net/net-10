using System;
using Zhdannov_hw9;

public class Program
{
    public static void Main(string[] args)
    {
        
        ATM atm = new ATM();

        
        ATMClient client = new ATMClient(atm);

        
        atm.BalanceChanged += newBalance => Console.WriteLine("New balance received: " + newBalance);

        
        client.InsertCard("1111111111", 1000);
        client.ViewBalance();
        client.Withdraw(500);
        client.TopUp(200);

        Console.ReadLine();
    }
}