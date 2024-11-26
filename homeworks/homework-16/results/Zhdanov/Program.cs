using System;
using Zhdanov_hw_16;

public class Program
{
    public static void Main(string[] args)
    {
        Shop shop = new Shop(2); 

        Person person1 = new Person("Gendalf", 2000);
        Person person2 = new Person("Thor", 3000);
        Person person3 = new Person("Anakin", 1500);

        shop.Enter(person1);
        shop.Enter(person2);
        shop.Enter(person3);

        shop.Close();
        Thread servingThread = new Thread(shop.ServeCustomer);
        servingThread.Start();
        servingThread.Join();

        Console.WriteLine("All customers have been served.");
    }
}