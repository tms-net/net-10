// See https://aka.ms/new-console-template for more information
using Banking;

Console.WriteLine("Hello, World!");

/*
var input = Console.ReadLine();

MyDelegate myDelegate1 = new MyDelegate(amount =>
              {
                  Console.WriteLine($"First Delegate {amount}");
                  return input == "Y";
              });

var firstDelegate = bool (long amount) =>
              {
                  Console.WriteLine($"First Delegate {amount}");
                  return true;
              };

var myDelegate = firstDelegate + new Func<long, bool>(myDelegate1);

// IMMUTABLE

Console.WriteLine(myDelegate.Invoke(100));

myDelegate = myDelegate + (x =>
                        {
                            Console.WriteLine($"Second Delegate ({x})");
                            return false;
                        });

Console.WriteLine(myDelegate.Invoke(200));

myDelegate -= (x =>
{
    Console.WriteLine("Third Delegate");
    return false;
});

Console.WriteLine(myDelegate.Invoke(300));

myDelegate -= firstDelegate;

Console.WriteLine(myDelegate.Invoke(400));
*/

var random = new Random();
var atm = new ATM(10000);

atm.Started += amount => true;

// myDelegate();

// myDelegate += amount => true;

atm.TransactionCompleted += (sender, args) =>
{
    Console.WriteLine($"Transaction completed: {args.BalanceAfter}");
};

for (int i = 0; i < 10; i++)
{
    var client = new ATMClient(atm);

    DoRandomActions(client);
}

// TODO: Реализуйте логику просмотра баланса пользователем

void DoRandomActions(ATMClient client)
{
    var actions = new[] { client.Withdraw, client.TopUp };

    client.InsertCard(random.Next(100, 10000));

    var numberOfActions = random.Next(10);
    for (int i = 0; i < numberOfActions; i++)
    {
        actions[random.Next(0,2)](random.Next(10, 1000));
    }
}