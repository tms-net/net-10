
using Bank;

internal partial class Program
{
    private static void Main(string[] args)
    {
        VIPClient[] ListOfClients = new VIPClient[2];
        
        VIPClient Evgeny = new VIPClient(
           "Evgeny",
           "Lipay",
           "Lipay8790@mail.ru",
           "12345hf",
           24,
           1000
           );
        VIPClient Alex = new VIPClient(
           "Alex",
           "Hogen",
           "AHogen@mail.ru",
           "7898yh",
           29
           );
        ListOfClients[0] = Evgeny;
        ListOfClients[1] = Alex;
        Console.WriteLine("Ваш баланс счета: " + Alex.GetBalane());
        Evgeny.AddMoney(200);
        Alex.AddMoney(200);
        Console.WriteLine("Ваш баланс счета: " + Alex.GetBalane());
        Console.ReadKey();
    }
}
   

    
