namespace patapau.Task2
{
    public interface IOperations
    {
        void Deposit(double sum);// Депозит на банковский счет
        void Withdrawal(double sum);// Вывод из банковского счета
        void CheckBalance();// Проверка баланса
        void Transfer();//Перевод
    }


    public interface IAccount
    {
        void CloseAccount(); // Закрытие счета
        void GetBankAccount();// Получить информацию о счете
    }

    //Базовый класс 
    public abstract class ClientBank : IAccount, IOperations
    {
        protected string bankAccount; //Банковской счет
        protected DateTime dateRegistrations;
        protected string name; //Имя клиента или название организации
        protected double balance;

        public virtual void Deposit(double sum)
        {
            balance += sum;
            Console.WriteLine($"Счет пополнен на {sum}");
        }
        public virtual void Withdrawal(double sum)
        {
            if (balance < sum)
            {
                Console.WriteLine("Недостаточно средств!");
            }
            else
            {
                balance -= sum;
                Console.Write($"Вывод средств {sum} ");
                Console.WriteLine("Текущий баланс физического лица равен " + balance);
            }
        }
        public virtual void CheckBalance()
        {
            Console.WriteLine("Текущий баланс физического лица равен " + balance);
        }
        public virtual void GetBankAccount()
        {
            Console.WriteLine($"Имя - {name}; Номер счета - {bankAccount}; Дата регистрации - {dateRegistrations.ToString()}");
        }
        public void CloseAccount()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }
    }






    //Класс физических лиц
    public class PhysicalСlients : ClientBank
    {
        private static Random random = new Random();
        public PhysicalСlients(string Name)
        {
            name = Name;
            bankAccount = $"PHY-{random.Next(100000, 1000000)}";
            dateRegistrations = DateTime.Now;
            balance = 0;
        }

        public override void GetBankAccount()
        {
            Console.WriteLine("Счет физического лица");
            base.GetBankAccount();
        }
    }








    //Класс  юридических лиц
    internal class LegalСlients : ClientBank
    {
        private double percentForOperation = 2;
        private static Random random = new Random();
        public LegalСlients(string Name)
        {
            name = Name;
            bankAccount = $"LEG-{random.Next(100000, 1000000)}";
            dateRegistrations = DateTime.Now;
            balance = 0;
        }

        public override void GetBankAccount()
        {
            Console.WriteLine("Счет юридического лица");
            base.GetBankAccount();
        }

        public override void Deposit(double sum)
        {
            balance += sum / 100 * (100 - percentForOperation);
            Console.WriteLine($"Счет пополнен на {sum / 100 * (100 - percentForOperation)}");
        }

        public override void Withdrawal(double sum)
        {
            if (balance < (sum / 100 * percentForOperation + sum))
                {
                Console.WriteLine("Недостаточно средств!");
            }
            else { 
            balance -= (sum / 100 * percentForOperation + sum);
                Console.Write($"Вывод средств {sum / 100 * percentForOperation + sum} ");
                Console.WriteLine("Текущий баланс юридического лица равен " + balance);
            }
        }

        public override void CheckBalance()
        {
            Console.WriteLine("Текущий баланс юридического лица равен " + balance);
        }
    }
}
