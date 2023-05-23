using System.Reflection;

namespace Banking
{
    internal class ATMClient
    {
        private ATM _atm;
        private decimal? _accountBalance; // Nullable Value Type

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
            AmountCheck(amount);
            if (_atm.WithdrawMoney(amount))
            {
                _accountBalance -= amount;
            }           
        }

        /// <summary>
        /// .Пополнить банкомат средствами
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        public void TopUp(long amount)
        {
            AmountCheck(amount);
            if (_accountBalance < amount)
            {
                _atm.TopUpMoney(amount);
                _accountBalance -= amount;
            }
        }

        /// <summary>
        /// Просмотр баланса пользователем
        /// </summary>
        public string ViewBalance()
        {
            return $"Acount balanse: {_accountBalance}";
        }

        private void AmountCheck(long amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can't do operation with \"negative\" amount of money");
            }
        }
    }
}