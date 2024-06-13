using ShopSimulator;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Hello, Shop!");

var random = new Random();
//var shop = new ShopWithThreadPool(3);
var shop = new ShopWithTasks(3);
//var shop = new Shop(3);

shop.Open();

for (int i = 0; i < 100; i++)
{
    var person = new Person(random.Next(100, 1000), i + 1);
    shop.Enter(person);

    Thread.Sleep(100);
}

shop.Close();

