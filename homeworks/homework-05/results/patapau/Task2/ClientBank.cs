namespace patapau.Task2
{
    //Базовый класс 
    public abstract class ClientBank : IAccount, IOperations
    {
        protected string bankAccount; //Банковской счет
        protected DateTime dateRegistrations;
        protected double balance;
        public string name { get; }//Имя клиента или название организации
        protected LogHistory LogHistory = new LogHistory(); 
        
        protected ClientBank(string Name)
        {
            name = Name;
            dateRegistrations = DateTime.Now;
            balance = 0;
        }

        public abstract void Deposit(double sum);
        public abstract void Withdrawal(double sum);
        public abstract void Transfer(ClientBank toClient, double sum);

        public virtual double CheckBalance()
        {
            return balance;
        }

        public virtual string GetBankAccount()
        {
            return $"Имя - {name}; Номер счета - {bankAccount}; Дата регистрации - {dateRegistrations}";
        }
        
        public virtual void CloseAccount()
        {
            throw new NotImplementedException();
        }
        
        public virtual List<Log> GetHistoryLogs()
        {
            var logs = LogHistory.GetFullHistoryLog();
            return logs;
        }
    }
}
