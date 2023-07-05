// See https://aka.ms/new-console-template for more information
using ShopSimulator;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello, Shop!");

new Timer(state =>
{
    Console.WriteLine($"Available Threads: {GetAvailableThreads()}");
}).Change(0, 500);

ThreadPool.SetMaxThreads(10, 10);

var random = new Random();
var shop = new Shop(100);

shop.Open();

for (int i = 0; i < 100; i++)
{
    var person = new Person(random.Next(1000, 5000), i + 1);
    shop.Enter(person);

    //Thread.Sleep(100);
}

shop.Close();


int GetAvailableThreads()
{
    ThreadPool.GetAvailableThreads(out var wt, out _);

    return wt;
}
