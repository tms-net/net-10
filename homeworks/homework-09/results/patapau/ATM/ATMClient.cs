namespace Banking
{
    internal class ATMClient
    {
        private ATM _atm;

        private decimal? _accountBalance; // Nullable Value Type

        public event EventHandler<ClientBalanceEventArgs> _clientBalance;

        public ATMClient(ATM atm)
        {
            _atm = atm;
        }

        /// <summary>
        /// Вставить карточку
        /// </summary>
        /// <param name="accountBalance">баланс карточки</param>
        public void InsertCard(decimal accountBalance)
        {
            _accountBalance = accountBalance;
        }

        /// <summary>
        /// Снять средства из банкомата
        /// </summary>
        /// <param name="amount">сумма для снятия</param>
        public void Withdraw(long amount)
        {
            if (amount <= _accountBalance)
            {
                _atm.WithdrawMoney(amount);
                _accountBalance -= amount;
            }
        }

        /// <summary>
        /// .Пополнить банкомат средствами
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        public void TopUp(long amount)
        {
            if (amount > 0)
            {
                _atm.TopUpMoney(amount);
                _accountBalance += amount;
            }
        }

        /// <summary>
        /// Просмотр баланса пользователем
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void ViewBalance()
        {
            ClientBalanceEventArgs args = new ClientBalanceEventArgs(_accountBalance);
            if (_clientBalance != null)
            {
                _clientBalance(this, args);
            }
        }
    }


    public class ClientBalanceEventArgs
    {
        public decimal? Balance { get; set; }

        public ClientBalanceEventArgs(decimal? balance)
        {
            Balance = balance;
        }
    }
}