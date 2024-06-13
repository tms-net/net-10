using BankOperations.Interfaces;

namespace BankOperations.Insurances
{
    public abstract class Insurance : IInsurance
    {
        public int InsuranceAmount { get; }
        public int CurrentInsuranceBalance { get; private set; }
        public IActor Client { get; }
        protected IActor Insurer { get; }

        protected Insurance(IActor client, IActor insurer, int insuranceAmount)
        {
            Client = client;
            Insurer = insurer;
            InsuranceAmount = insuranceAmount;
            CurrentInsuranceBalance = insuranceAmount;
        }

        public int GetInsuranceAmount() => InsuranceAmount;

        public int GetCurrentInsuranceBalance() => InsuranceAmount;

        public void DecreaseInsuranceAmount(int amount) => CurrentInsuranceBalance -= amount;
        
        public void IncreaseInsuranceAmount(int amount) => CurrentInsuranceBalance += amount;

        public virtual bool IsValid()
        {
            if (Client == null || Insurer == null)
            {
                return false;
            }

            return true;
        }

        public void Reclaim()
        {
            CurrentInsuranceBalance = InsuranceAmount;
        }
    }
}