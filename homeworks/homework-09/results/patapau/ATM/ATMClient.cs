namespace Banking
{
    internal class ATMClient
    {
        private ATM _atm;

        private decimal? _accountBalance; // Nullable Value Type

        private TransactionStatus _transactionStatus;

        public event EventHandler<ClientEventArgs> _clientEvent;

        public ATMClient(ATM atm)
        {
            _atm = atm;
            _atm._transactionCompleted += CheckTransaction;
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

            if (amount <= 0 || amount > _accountBalance)
            {
                ClientEventArgs args = new ClientEventArgs();
                args.TransactionStatus = TransactionStatus.Failed;
                args.TransactionError = "Incorrect withdrawal amount";
                if (_clientEvent != null)
                {
                    _clientEvent(this, args);
                }
            }
            else
            {
                _atm.WithdrawMoney(amount);
                if (_transactionStatus == TransactionStatus.Succeeded)
                {
                    _accountBalance -= amount;
                }
            }
        }
        /// <summary>
        /// .Пополнить банкомат средствами
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        public void TopUp(long amount)
        {
            _atm.TopUpMoney(amount);
            if (_transactionStatus == TransactionStatus.Succeeded)
            {
                _accountBalance += amount;
            } 
        }

        /// <summary>
        /// Просмотр баланса пользователем
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void ViewBalance()
        {
            ClientEventArgs args = new ClientEventArgs(_accountBalance);
            if (_clientEvent != null)
            {
                _clientEvent(this, args);
            }
        }

        void CheckTransaction(object sender, TransactionEventArgs args)
        {
            _transactionStatus = args.TransactionStatus;
        }


    }


    public class ClientEventArgs
    {
        public decimal? Balance { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public string TransactionError { get; set; }
        public ClientEventArgs()
        {

        }
        public ClientEventArgs(decimal? balance)
        {
            Balance = balance;
        }
    }
}