using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KlindyukHW5.BankOpeartion.Entities

{
    internal class Bank : ITransfer
    {

        internal List<Client> clients = new List<Client>() { new Client(400000) };
        internal List<PremiumClients> prClients = new List<PremiumClients>() { new PremiumClients(700000) };
        private Dictionary<int, int> bankAccounts = new()  //Client ID and SUM
        {
            [400000] = 300,
            [700000] = 2400
        };

        internal Bank(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int id = rnd.Next(400000, 999999);
                int sum = rnd.Next(500, 700 + 1);
                if (id >= 700000)
                {
                    var newPrClient = new PremiumClients(id); ;
                    prClients.Add(newPrClient);
                    bankAccounts.Add(newPrClient.ClientId, newPrClient.Deposit + sum);
                }
                else
                {
                    var newClient = new Client(id);
                    clients.Add(newClient);
                    bankAccounts.Add(newClient.ClientId, sum);
                }
            }
            GetInformation();
        }

        public string Transfer(int senderID, int recipientID, int transferSum)
        {
            if (bankAccounts[senderID] >= transferSum)
            {
                bankAccounts[senderID] -= transferSum;
                bankAccounts[recipientID] += transferSum;
                return $"\nSender: {senderID}: WAS: {bankAccounts[senderID] + transferSum} NOW: {bankAccounts[senderID]}\n" +
                $"Recipient: {recipientID}: WAS: {bankAccounts[recipientID] - transferSum} NOW: {bankAccounts[recipientID]}";
            }
            else
            {
                return "Error! Check your balance!";
            }
        }

        public string GetInformation()
        {
            string result = "";
            foreach (var account in bankAccounts)
            {
                if (account.Key >= 700000)
                {
                    result += $"Premium Client  ID: {account.Key}  SUM: {account.Value}\n";
                }
                else
                {
                    result += $"Standart Client ID: {account.Key}  SUM: {account.Value}\n";
                }
            }
            result += "\nStandart Clients ID";
            foreach (var client in clients)
            {
                result += $"\n{client.ClientId}";
            }
            result += "\n\nPremium Clients ID";

            foreach (var prClient in prClients)
            {
                result += $"\n{prClient.ClientId}";
            }
            return result;
        }

    }
}
