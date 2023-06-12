namespace BankOperations.Interfaces
{
    public interface IInsurance
    {
        int GetInsuranceAmount();
        bool IsValid();
        void DecreaseInsuranceAmount(int amount);
        void IncreaseInsuranceAmount(int amount);
        void Reclaim();

    }
}