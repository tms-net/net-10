
using Banking;

var random = new Random();
var atm = new ATM(10000);


atm._transactionCompleted += (sender, args) =>
{
    Console.WriteLine($"Transaction completed: {args.BalanceAfter}");
};

for (int i = 0; i < 10; i++)
{
    var client = new ATMClient(atm);
    client._clientBalance += GetClientBalance;
    Console.Write($"Client {i + 1} ");
    DoRandomActions(client);
}

void GetClientBalance(object sender, ClientBalanceEventArgs args)
{
    Console.WriteLine($"Client balance {args.Balance}");
}

void DoRandomActions(ATMClient client)
{
    var actions = new[] { client.Withdraw, client.TopUp };

    client.InsertCard(random.Next(100, 10000));
    client.ViewBalance();
    var numberOfActions = random.Next(10);
    for (int i = 0; i < numberOfActions; i++)
    {
        actions[random.Next(0,2)](random.Next(10, 1000));
        client.ViewBalance();
    }
}