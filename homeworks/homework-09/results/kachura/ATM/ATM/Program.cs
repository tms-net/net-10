// See https://aka.ms/new-console-template for more information
using Banking;

var random = new Random();
var atm = new ATM(10000);
atm.TransactionCompleted += (sender, args) =>
{
    Console.WriteLine($"Transaction completed: {args.BalanceAfter}");
};

for (int i = 0; i < 10; i++)
{
    var client = new ATMClient(atm);

    client.ViewBalanceEvent += ShowBalance;
    DoRandomActions(client);
}

void ShowBalance(decimal? amount)
{
    Console.WriteLine($"Current client's balance is {amount}");
}

void DoRandomActions(ATMClient client)
{
    var actions = new[] { client.Withdraw, client.TopUp };

    client.InsertCard(random.Next(100, 10000));

    var numberOfActions = random.Next(10);
    for (int i = 0; i < numberOfActions; i++)
    {
        var action = random.Next(0, 3);
        if (action < 2)
        {
            actions[action](random.Next(10, 1000));
        }
        else
        {
            client.ViewBalance();
        }
    }
}