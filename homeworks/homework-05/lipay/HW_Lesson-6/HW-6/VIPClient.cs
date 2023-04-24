

namespace Bank
{
    class VIPClient : Client
    {
        public VIPClient(string firstName, string secondName, string email, string password, int age, int bankBalance = 0) : base(firstName, secondName, email, password, age, bankBalance) 
        {
        }
    }
}
    
