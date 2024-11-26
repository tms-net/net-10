
using Banking;

var random = new Random();
var atm = new ATM(10000);


atm._transactionCompleted += (sender, args) =>
{
    if (args.TransactionStatus == TransactionStatus.Succeeded)
    {
        Console.WriteLine($"Transaction completed: {args.BalanceAfter}");
    }
    else
    {
        Console.WriteLine($"Transaction error: {args.TransactionError}");
    }
};

for (int i = 0; i < 10; i++)
{
    var client = new ATMClient(atm);
    client._clientEvent += GetClientEvent;
    Console.WriteLine($"Client {i + 1} ");
    DoRandomActions(client);
}

void GetClientEvent(object sender, ClientEventArgs args)
{
    if (args.TransactionStatus == TransactionStatus.Failed)
    {
        Console.WriteLine($"Incorrect withdrawal amount");
    }
    else
    {
        Console.WriteLine($"Client balance {args.Balance}");
    }
}

void DoRandomActions(ATMClient client)
{
    var actions = new[] { client.Withdraw, client.TopUp };

    client.InsertCard(random.Next(100, 10000));
    client.ViewBalance();
    var numberOfActions = random.Next(10);
    for (int i = 0; i < numberOfActions; i++)
    {
        actions[random.Next(0, 2)](random.Next(10, 1000));
        client.ViewBalance();
    }
}