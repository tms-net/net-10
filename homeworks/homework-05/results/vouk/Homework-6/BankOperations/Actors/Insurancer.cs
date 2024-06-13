using BankOperations.Interfaces;

namespace BankOperations.Actors
{
    public class Insurancer : Actor
    {
        public List<Client> ListOfInsurancerClients { get; }
        public string InsurancerCompanyName { get;  }

        public Insurancer(bool isActorClient, string insurancerCompanyName) : base(isActorClient)
        {
            InsurancerCompanyName = insurancerCompanyName;
        }

        public void AddInsurance(Client actor) => ListOfInsurancerClients.Add(actor);

        public List<IInsurance> GetAllInsurancesOfInsurancerClients()
        {
            var listOfAllInsurances = new List<IInsurance>();
            ListOfInsurancerClients.ForEach(client => listOfAllInsurances.AddRange(client.ListOfClientInsurances));

            return listOfAllInsurances;
        }
    }
}