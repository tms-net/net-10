using BankOperations.Interfaces;

namespace BankOperations.Insurances
{
    public class AutoInsurance : Insurance, IAutomobile
    {
        public bool IsInsuranceCasco { get; set; }
        public int TransportCost { get; set; }

        public AutoInsurance(IActor client, IActor insurer, int insuranceAmount, bool isCasco, int transportCost) : base(client, insurer, insuranceAmount)
        {
            IsInsuranceCasco = isCasco;
            TransportCost = transportCost;
        }

        public IAutomobile Automobile { get; set; }

        public override bool IsValid()
        {
            if (Automobile == null)
            {
                return false;
            }

            return base.IsValid();
        }


        public bool IsCasco() => IsInsuranceCasco;

        public int GetTransportCost() => TransportCost;
    }
}