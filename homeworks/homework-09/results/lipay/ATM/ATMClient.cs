namespace Banking
{
    internal class ATMClient
    {
        private ATM _atm;
        private decimal? _accountBalance; // Nullable Value Type
        public string _cardStatus;
        public CardStatus cardStatus = CardStatus.Failed;
        

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
            // TODO: Выполнить валидацию проведения операции
            if (_accountBalance >= amount)
            {
                _atm.WithdrawMoney(amount);
                _accountBalance -= amount;
                cardStatus = CardStatus.Succeeded;
            }
            else
            {
                cardStatus = CardStatus.Failed;
                _cardStatus = "Not enough money on card";
            }
         
        }

        /// <summary>
        /// .Пополнить банкомат средствами
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        public void TopUp(long amount)
        {
            // TODO: Реализовать пополнение баланса
            _accountBalance += amount;
            _atm.TopUpMoney(amount);
        }

        /// <summary>
        /// Просмотр баланса пользователем
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public decimal? ViewBalance()
        {
            // TODO: Реализовать Просмотр баланса
            if (_accountBalance != null)
            {
                return _accountBalance.Value;
            }
            else
            {
                return null;
            }
        }
        public enum CardStatus
        {
            Succeeded,
            Failed
        }
    }
}