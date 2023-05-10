// See https://aka.ms/new-console-template for more information
using Banking;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var random = new Random();
        var atm = new ATM(10000);
        atm.TransactionCompleted += (sender, args) =>
        {
            Console.WriteLine($"Transaction completed: {args.BalanceAfter}");
        };       

        for (int i = 0; i < 10; i++)
        {
            var client = new ATMClient(atm);
            ShowBalance delegenerate = new ShowBalance(client.ViewBalance);
            DoRandomActions(client);
            Console.WriteLine(delegenerate.Invoke());           
        }

        // TODO: Реализуйте логику просмотра баланса пользователем

        void DoRandomActions(ATMClient client)
        {
            var actions = new[] { client.Withdraw, client.TopUp};
            client.InsertCard(random.Next(100, 10000));

            var numberOfActions = random.Next(10);
            for (int i = 0; i < numberOfActions; i++)
            {
                actions[random.Next(0, 2)](random.Next(10, 1000));
            }
        }
    }
    public delegate string ShowBalance();

}