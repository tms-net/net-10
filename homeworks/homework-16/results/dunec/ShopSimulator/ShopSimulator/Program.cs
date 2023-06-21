// See https://aka.ms/new-console-template for more information
using ShopSimulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Hello, Shop!");

        var random = new Random();
        var shop = new Shop(30);

        shop.Open();

        for (int i = 0; i < 100; i++)
        {
            var person = new Person(random.Next(100, 1000), i + 1);
            shop.Enter(person);

            Thread.Sleep(random.Next(100));
        }

        shop.Close();
    }
}