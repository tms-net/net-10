namespace patapau.Task2
{
    //Базовый класс 
    public abstract class ClientBank : IAccount, IOperations, ILogs
    {
        protected string bankAccount; //Банковской счет
        protected DateTime dateRegistrations;
        protected double balance;
        protected List<Log> logs = new List<Log>();//хранение логов операций 
        public string name { get; }//Имя клиента или название организации
        
        
        protected ClientBank(string Name)
        {
            name = Name;
            dateRegistrations = DateTime.Now;
            balance = 0;
        }


        public abstract void Deposit(double sum);
        public abstract void Withdrawal(double sum);
        public abstract double CheckBalance();
        public abstract void Transfer(ClientBank toClient, double sum);


        public virtual string GetBankAccount()
        {
            return $"Имя - {name}; Номер счета - {bankAccount}; Дата регистрации - {dateRegistrations}";
        }


        public void CloseAccount()
        {
            throw new NotImplementedException();
        }
        
        public List<Log> GetHistoryLog()//Возвращает историю логов
        {
            return logs;
        }

        public virtual string GetOperationStatus()
        {
            var operationLogs = GetHistoryLog();
            return operationLogs[operationLogs.Count - 1].GetLog();
        }
    }
}
