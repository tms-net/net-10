namespace Banking
{
    internal class ATMClient
    {
        ATM _atm { get; set; }
        decimal? AccountBalance { get; set; } // Nullable Value Type
        public CardStatus cardStatus = CardStatus.Undefined;
        

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
            AccountBalance = accountBalance;
        }

        /// <summary>
        /// Снять средства из банкомата
        /// </summary>
        /// <param name="amount">сумма для снятия</param>
        public void Withdraw(long amount)
        {
            // TODO: Выполнить валидацию проведения операции
           
            if (AccountBalance >= amount)
            {
                _atm.WithdrawMoney(amount);
                AccountBalance -= amount;
                cardStatus = CardStatus.Succeeded;
            }
            else
            {
                cardStatus = CardStatus.Undefined;
            }
         
        }

        /// <summary>
        /// Пополнить банкомат средствами
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        public void TopUp(long amount)
        {
            // TODO: Реализовать пополнение баланса
            if (AccountBalance == null)
            {
                cardStatus = CardStatus.Undefined;
            }
            else
            {
                AccountBalance += amount;
                _atm.TopUpMoney(amount);
                cardStatus = CardStatus.Succeeded;
            }
         
        }

        /// <summary>
        /// Просмотр баланса пользователем
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public decimal? ViewBalance()
        {
            // TODO: Реализовать Просмотр баланса
            if (AccountBalance != null)
            {
                return AccountBalance.Value;
            }
            else
            {
                return null;
            }
        }
        public enum CardStatus
        {
            Succeeded,
            Undefined
        }
    }
}