namespace patapau.Task2
{
    public interface IOperations
    {
        void Deposit(double sum);// Депозит на банковский счет
        void Withdrawal(double sum);// Вывод из банковского счета
        double CheckBalance();// Проверка баланса
        void Transfer(ClientBank toClient, double sum);//Перевод
    }
}
