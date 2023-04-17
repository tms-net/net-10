using System;

namespace patapau.Task2
{
    public interface IOperations
    {
        void Deposit(double sum);// Депозит на банковский счет
        void Withdrawal(double sum);// Вывод из банковского счета
        void CheckBalance();// Проверка баланса
        void Transfer(IOperations toClient, double sum);//Перевод
        string name { get; }//Имя клиента выполняющего операцию
    }



    public interface IAccount
    {
        void CloseAccount(); // Закрытие счета
        void GetBankAccount();// Получить информацию о счете
    }

    //Базовый класс 
    public abstract class ClientBank : IAccount, IOperations
    {
        protected string bankAccount = "000000"; //Банковской счет
        protected DateTime dateRegistrations;
        protected double balance;
        public string name { get; }//Имя клиента или название организации

        protected ClientBank(string Name)
        {
            name = Name;
            dateRegistrations = DateTime.Now;
            balance = 0;
        }
        public abstract void Deposit(double sum);
        public abstract void Withdrawal(double sum);
        public abstract void CheckBalance();
 
        public virtual void Transfer(IOperations toClient, double sum)
        {
            Console.WriteLine($"Перевод средств от {this.name} к {toClient.name} выполнен");
            this.Withdrawal(sum);
            toClient.Deposit(sum);
        }
        public virtual void GetBankAccount()
        {
            Console.WriteLine($"Имя - {name}; Номер счета - {bankAccount}; Дата регистрации - {dateRegistrations.ToString()}");
        }

        public void CloseAccount()
        {
            throw new NotImplementedException();
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
            Console.Write($"Счет пополнен на {sum} ");
            CheckBalance();
        }
        public override void Withdrawal(double sum)
        {
            if (balance < sum)
            {
                Console.WriteLine("Недостаточно средств!");
            }
            else
            {
                balance -= sum;
                Console.Write($"Вывод средств {sum} ");
                CheckBalance();
            }
        }
        public override void CheckBalance()
        {
            Console.WriteLine("Текущий баланс физического лица равен " + balance);
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
        private readonly double percentForOperation = 2;//комиссия банка за операции

        public LegalСlients(string name) : base(name)
        {
            bankAccount = $"LEG-{new Random().Next(100000, 1000000)}";
        }
        public override void Deposit(double sum)
        {
            balance += sum / 100 * (100 - percentForOperation);
            Console.Write($"Счет пополнен на {sum} с учетом комиссии {sum / 100 * (100 - percentForOperation)} ");
            Console.WriteLine("Текущий баланс юридического лица равен " + balance);
        }
        public override void Withdrawal(double sum)
        {
            if (balance < (sum / 100 * percentForOperation + sum))
                {
                Console.WriteLine("Недостаточно средств!");
            }
            else { 
            balance -= (sum / 100 * percentForOperation + sum);
                Console.Write($"Вывод средств {sum} с учетом комиссии {sum / 100 * percentForOperation + sum} ");
                Console.WriteLine("Текущий баланс юридического лица равен " + balance);
            }
        }
        public override void CheckBalance()
        {
            Console.WriteLine("Текущий баланс юридического лица равен " + balance);
        }
        public override void GetBankAccount()
        {
            Console.WriteLine("Счет юридического лица");
            base.GetBankAccount();
        }
    }
}
