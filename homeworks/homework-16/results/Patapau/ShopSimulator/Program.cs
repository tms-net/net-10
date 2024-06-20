// See https://aka.ms/new-console-template for more information
using ShopSimulator;

Console.WriteLine("Hello, Shop!");

var random = new Random();
var shop = new Shop(3);

shop.Open();

for (int i = 0; i < 50; i++)
{
    var person = new Person(random.Next(100, 1000), i + 1);
    shop.Enter(person);

    Thread.Sleep(100);
}

shop.Close();
