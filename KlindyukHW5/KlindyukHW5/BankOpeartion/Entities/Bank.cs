using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion.Entities
{
    internal class Bank : ITransfer
    {
        internal Client[] clients;
        internal Client[] prClients;

        internal Bank(int amount)
        {
            Random rnd = new Random();
            clients = new Client[amount];
            prClients = new PremiumClients[amount];
            for (int i = 0; i < clients.Length; i++)
            {
                int id = rnd.Next(100000, 999999 + 1);
                int sum = rnd.Next(0, 500 + 1);
                clients[i] = new Client(id, sum);
                prClients[i] = new PremiumClients(id, sum);
            }
            ShowClients();
        }

        public void Transfer(Client sender, Client recipient, int transferSum)
        {
            if (sender.Sum >= transferSum)
            {
                sender.Sum -= transferSum;
                recipient.Sum += transferSum;
                Console.WriteLine($"Sender: {sender.ClientId}: WAS: {sender.Sum + transferSum} NOW: {sender.Sum}");
                Console.WriteLine($"Recipient: {recipient.ClientId}: WAS: {recipient.Sum - transferSum} NOW: {recipient.Sum}");
            }
            else { Console.WriteLine("Error! Check your balance!"); }
        }

        public void ShowClients()
        {
            Console.WriteLine("Premium:");
            foreach (Client prClient in prClients)
            {
                Console.WriteLine($"ID: {prClient.ClientId} | SUM: {prClient.Sum}");
            }
            Console.WriteLine("\nStandart:");
            foreach (Client client in clients)
            {
                Console.WriteLine($"ID: {client.ClientId} | SUM: {client.Sum}");
            }
            Console.WriteLine();
        }
    }
}
