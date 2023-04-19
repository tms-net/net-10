namespace patapau.Task2
{
    //Класс для 
    public class Log
    {
        public DateTime _date { get; }// Дата лога
        public string _message { get; }// Описание события 
        public string _category { get; }// Тип события (Перевод, Пополнение, Ошибка, Вывод)
        public double _balance { get; }// Баланс после операции
        public Log(DateTime date, string message, string category, double balance)
        {
            _date = date;
            _message = message;
            _category = category;
            _balance = balance;
        }
        public string GetLog()
        {
            return $"Log: Дата - {_date} Категория - {_category} \nСообщение - {_message} \nТекущий баланс - {_balance}\n-----------------------------------------------------------";
        }
    }

    public interface IHistory
    {
        IEnumerable<Log> GetHistoryLog();// Загрузка по
    }

    public interface IOperations
    {
        void Deposit(double sum);// Депозит на банковский счет
        void Withdrawal(double sum);// Вывод из банковского счета
        string CheckBalance();// Проверка баланса
        void Transfer(IOperations toClient, double sum);//Перевод
        string name { get; }//Имя клиента выполняющего операцию
    }



    public interface IAccount
    {
        void CloseAccount(); // Закрытие счета
        string GetBankAccount();// Получить информацию о счете
    }

    //Базовый класс 
    public abstract class ClientBank : IAccount, IOperations, IHistory
    {
        protected string bankAccount = "000000"; //Банковской счет
        protected DateTime dateRegistrations;
        protected double balance;
        protected List<Log> logs = new List<Log>();
        public string name { get; }//Имя клиента или название организации

        protected ClientBank(string Name)
        {
            name = Name;
            dateRegistrations = DateTime.Now;
            balance = 0;
        }
        public abstract void Deposit(double sum);
        public abstract void Withdrawal(double sum);
        public abstract string CheckBalance();

        public virtual void Transfer(IOperations toClient, double sum)
        {
            if (balance < sum)
            {
                logs.Add(new Log(DateTime.Now, $"Недостаточно средств для перевода {sum}", "Ошибка", balance));
                throw new InvalidOperationException("Недостаточно средств для перевода!");
            }
            else
            {
                Withdrawal(sum);
                toClient.Deposit(sum);
                logs.Add(new Log(DateTime.Now, $"Перевод средств от {this.name} к {toClient.name} выполнен", "Перевод", balance));
            }
        }
        public virtual string GetBankAccount()
        {
            return $"Имя - {name}; Номер счета - {bankAccount}; Дата регистрации - {dateRegistrations.ToString()}";
        }

        public void CloseAccount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> GetHistoryLog()
        {
            return logs;
        }
    }






    //Класс физических лиц
    public class PhysicalСlients : ClientBank
    {
        public PhysicalСlients(string name) : base(name)
        {
            bankAccount = $"PHY-{new Random().Next(100000, 1000000)}";
        }
        public override void Deposit(double sum)
        {
            balance += sum;
            logs.Add(new Log(DateTime.Now, $"Счет пополнен на {sum} ", "Пополнение", balance));
        }
        public override void Withdrawal(double sum)
        {
            if (balance < sum)
            {
                logs.Add(new Log(DateTime.Now, $"Недостаточно средств для вывода {sum}", "Ошибка", balance));
                throw new InvalidOperationException("Недостаточно средств для вывода!");
            }
            else
            {
                balance -= sum;
                logs.Add(new Log(DateTime.Now, $"Со счета снято {sum} ", "Вывод", balance));
            }
        }
        public override string CheckBalance()
        {
            return $"Текущий баланс физического лица равен " + balance;
        }
    }








    //Класс  юридических лиц
    internal class LegalСlients : ClientBank
    {
        private readonly double percentForOperation = 2;//комиссия банка за операции

        public LegalСlients(string name) : base(name)
        {
            bankAccount = $"LEG-{new Random().Next(100000, 1000000)}";
        }
        public override void Deposit(double sum)
        {
            balance += sum / 100 * (100 - percentForOperation);
            logs.Add(new Log(DateTime.Now, $"Счет пополнен на {sum} с учетом комиссии {sum / 100 * (100 - percentForOperation)} ", "Пополнение", balance));
        }
        public override void Withdrawal(double sum)
        {
            if (balance < (sum / 100 * percentForOperation + sum))
            {
                logs.Add(new Log(DateTime.Now, $"Недостаточно средств для вывода с учетом комиссии {(sum / 100 * percentForOperation + sum)}", "Ошибка", balance));
                throw new InvalidOperationException("Недостаточно средств для вывода!");
            }
            else
            {
                balance -= (sum / 100 * percentForOperation + sum);
                logs.Add(new Log(DateTime.Now, $"Вывод средств {sum} с учетом комиссии {sum / 100 * percentForOperation + sum} ", "Вывод", balance));
            }
        }
        public override string CheckBalance()
        {
            return "Текущий баланс юридического лица равен " + balance;
        }
    }
}
