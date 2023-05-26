using System.Net.Sockets;

namespace patapau.Task2
{
    //Класс физических лиц
    public class PhysicalСlients : ClientBank
    {
        public PhysicalСlients(string name) : base(name)
        {
            bankAccount = $"PHY-{new Random().Next(100000, 1000000)}";
            LogHistory.AddLog($"Счет {bankAccount} успешно создан", "Создание счета", balance);
        }

        public override void Deposit(double sum)
        {
            if (sum <= 0)
            {
                LogHistory.AddLog($"Указано недопустимое значение для депозита: {sum}", "Ошибка", balance);
                throw new ArgumentException("Указано недопустимое значение для депозита", nameof(sum));
            }
            balance += sum;
            LogHistory.AddLog($"Счет пополнен на {sum} ", "Пополнение", balance);
        }

        public override void Withdrawal(double sum)
        {
            if (sum <= 0 || sum > balance)
            {
                LogHistory.AddLog($"Указано недопустимое значение для вывода: {sum}", "Ошибка", balance);
                throw new ArgumentException("Указано недопустимое значение для вывода.", nameof(sum));
            }
            balance -= sum;
            LogHistory.AddLog($"Вывод средств {sum}", "Вывод", balance);
        }

        public override void Transfer(ClientBank toClient, double sum)
        {
            if (sum <= 0 || sum > balance)
            {
                LogHistory.AddLog($"Указано недопустимое значение для перевода: {sum}", "Ошибка", balance);
                throw new ArgumentException("Указано недопустимое значение для перевода.", nameof(sum));
            }

            if (this == toClient || toClient == null)
            {
                LogHistory.AddLog($"Неверно указан адресат перевода", "Ошибка", balance);
                throw new InvalidOperationException("Неверно указан адресат перевода.");
            }

            balance -= sum;
            toClient.Deposit(sum);
            LogHistory.AddLog($"Перевод средств на сумму {sum} от {name} к {toClient.name} выполнен", "Перевод", balance);
        }
    }
}
