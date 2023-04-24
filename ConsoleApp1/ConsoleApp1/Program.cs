using System.Net.Http.Headers;
using BankOperations.Actors;
using BankOperations.Insurances;

namespace BankOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var insurancer = new Insurancer(false, "Белгосстрах");
            var firstClient = new Client(true);
            var secondClient = new Client(true);
            var firstTransportInsuranceForFirstClient = new AutoInsurance(firstClient, insurancer, 10000, true, 50000);
            var secondTransportInsuranceForFirstClient = new AutoInsurance(firstClient, insurancer, 5000, false, 25000);
            var transportInsuranceForSecondClient = new AutoInsurance(secondClient, insurancer, 50000, true, 75000);
        }
    }
}
