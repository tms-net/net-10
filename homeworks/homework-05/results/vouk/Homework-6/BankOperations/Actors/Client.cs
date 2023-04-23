using BankOperations.Interfaces;

namespace BankOperations.Actors
{
    public class Client : Actor
    {
        public List<IInsurance> ListOfClientInsurances { get; }

        public Client(bool isActorClient) : base(isActorClient)
        {
        }

        public void AddInsurance(IInsurance insurance) => ListOfClientInsurances.Add(insurance);
    }
}