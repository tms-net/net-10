
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
    var S = client.cardStatus;
    DoRandomActions(client);
    if (S != client.cardStatus)
    {
        Console.WriteLine($"Current balance:{client.ViewBalance()}");
    }
    else
    {
        Console.WriteLine("Not enough money on card");
    }

  
}


Console.ReadLine();
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