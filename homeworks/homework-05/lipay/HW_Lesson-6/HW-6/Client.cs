
namespace Bank
{
    internal abstract class Client : IClient, IOperations
    {
        protected Client(string firstName, string secondName, string email, string password, int age, int bankBalance = 0)
        {
            FirstName = firstName;
            SecondName = secondName;
            Email = email;
            Password = password;
            Age = age;
            BankBalance = bankBalance;
            BankAccounts = rnd.Next(1,11);
        }
 
        public  string FirstName { get; }
        public  string SecondName { get; }
        public  string Email { get; }
        public  string Password { get; }
        public  int Age { get; }
        public int BankAccounts { get; } //Номер банковского аккаунта
        internal int BankBalance { get; set; }

        private Random rnd = new Random();
        

        public virtual void AddMoney(int money)
        {
            BankBalance += money;
        }

        public virtual int GetBalane()
        {
            return BankBalance;
        }
    }
}
    
