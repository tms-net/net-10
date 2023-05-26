namespace patapau.Task2
{
    //Класс  юридических лиц
    internal class LegalСlients : ClientBank
    {
        private readonly double percentForOperation = 2;//комиссия банка за операции

        public LegalСlients(string name) : base(name)
        {
            bankAccount = $"LEG-{new Random().Next(100000, 1000000)}";
            LogHistory.AddLog($"Счет {bankAccount} успешно создан", "Создание счета", balance);
        }

        public override void Deposit(double sum)
        {
            if (sum <= 0)
            {
                LogHistory.AddLog($"Указано недопустимое значение для депозита: {sum}", "Ошибка", balance);
                throw new ArgumentException("Указано недопустимое значение для депозита", nameof(sum));
            }
            else
            {
                balance += sum / 100 * (100 - percentForOperation);
                LogHistory.AddLog($"Счет пополнен на {sum} с учетом комиссии {sum / 100 * (100 - percentForOperation)} ", "Пополнение", balance);

            }
        }

        public override void Withdrawal(double sum)
        {
            if (sum <= 0 || (sum / 100 * percentForOperation + sum) > balance)
            {
                LogHistory.AddLog($"Указано недопустимое значение для вывода {sum} с учетом комиссии {(sum / 100 * percentForOperation + sum)}", "Ошибка", balance);
                throw new ArgumentException("Указано недопустимое значение для вывода.", nameof(sum));
            }
            balance -= (sum / 100 * percentForOperation + sum);
            LogHistory.AddLog($"Вывод средств {sum} с учетом комиссии {sum / 100 * percentForOperation + sum} ", "Вывод", balance);

        }

        public override void Transfer(ClientBank toClient, double sum)
        {

            if (sum <= 0 || (sum / 100 * percentForOperation + sum) > balance)
            {
                LogHistory.AddLog($"Указано недопустимое значение для перевода {sum} с учетом комиссии {(sum / 100 * percentForOperation + sum)}", "Ошибка", balance);
                throw new ArgumentException("Указано недопустимое значение для перевода.", nameof(sum));
            }

            if (this == toClient || toClient == null)
            {
                LogHistory.AddLog($"Неверно указан адресат перевода", "Ошибка", balance);
                throw new InvalidOperationException("Неверно указан адресат перевода.");
            }

            balance -= (sum / 100 * percentForOperation + sum);
            toClient.Deposit(sum);
            LogHistory.AddLog($"Перевод средств на сумму {sum} от {name} к {toClient.name} выполнен", "Перевод", balance);
        }
    }
}
