namespace patapau.Task2
{
    //Класс  юридических лиц
    internal class LegalСlients : ClientBank
    {
        private readonly double percentForOperation = 2;//комиссия банка за операции

        public LegalСlients(string name) : base(name)
        {
            bankAccount = $"LEG-{new Random().Next(100000, 1000000)}";
            logs.Add(new Log(DateTime.Now, $"Счет {bankAccount} успешно создан", "Создание счета", balance));
        }

        public override void Deposit(double sum)
        {
            if (sum <= 0)
            {
                logs.Add(new Log(DateTime.Now, $"Нельзя пополнить счет на {sum}", "Ошибка", balance));
            }
            else
            {
                balance += sum / 100 * (100 - percentForOperation);
                logs.Add(new Log(DateTime.Now, $"Счет пополнен на {sum} с учетом комиссии {sum / 100 * (100 - percentForOperation)} ", "Пополнение", balance));
            }
        }

        public override void Withdrawal(double sum)
        {
            switch (sum)
            {
                case var _ when sum <= 0:
                    logs.Add(new Log(DateTime.Now, $"Сумма вывода меньше или равна 0", "Ошибка", balance));
                    break;
                case var _ when (sum / 100 * percentForOperation + sum) > balance:
                    logs.Add(new Log(DateTime.Now, $"Недостаточно средств для вывода с учетом комиссии {(sum / 100 * percentForOperation + sum)}", "Ошибка", balance));
                    break;
                default:
                    balance -= (sum / 100 * percentForOperation + sum);
                    logs.Add(new Log(DateTime.Now, $"Вывод средств {sum} с учетом комиссии {sum / 100 * percentForOperation + sum} ", "Вывод", balance));
                    break;
            }
        }
        public override double CheckBalance()
        {
            return balance;
        }

        public override void Transfer(ClientBank toClient, double sum)
        {
            switch (sum)
            {
                case var _ when sum <= 0:
                    logs.Add(new Log(DateTime.Now, $"Сумма вывода меньше или равна 0", "Ошибка", balance));
                    break;
                case var _ when (sum / 100 * percentForOperation + sum) > balance:
                    logs.Add(new Log(DateTime.Now, $"Недостаточно средств для перевода {(sum / 100 * percentForOperation + sum)}", "Ошибка", balance));
                    break;
                case var _ when this == toClient:
                    logs.Add(new Log(DateTime.Now, $"Нельзя переводить переводить деньги себе на счет", "Ошибка", balance));
                    break;
                case var _ when toClient == null:
                    logs.Add(new Log(DateTime.Now, $"Не существует указанного счета", "Ошибка", balance));
                    break;
                default:
                    balance -= (sum / 100 * percentForOperation + sum);
                    toClient.Deposit(sum);
                    var toClientLogs = toClient.GetHistoryLog();
                    toClientLogs[toClientLogs.Count - 1] = new Log(DateTime.Now, $"{toClientLogs[toClientLogs.Count - 1].Message} Перевод средств от {name} выполнен", "Перевод", toClientLogs[toClientLogs.Count - 1].Balance);
                    logs.Add(new Log(DateTime.Now, $"Перевод средств на сумму {(sum / 100 * percentForOperation + sum)} от {name} к {toClient.name} выполнен", "Перевод", balance));
                    break;
            }
        }
    }
}
