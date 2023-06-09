﻿namespace Banking
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
            // TODO: Выполнить валидацию проведения операции

            _atm.WithdrawMoney(amount);
            _accountBalance -= amount;
        }

        /// <summary>
        /// .Пополнить банкомат средствами
        /// </summary>
        /// <param name="amount">сумма пополнения</param>
        public void TopUp(long amount)
        {
            // TODO: Реализовать пополнение баланса

            throw new NotImplementedException();
        }

        /// <summary>
        /// Просмотр баланса пользователем
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void ViewBalance()
        {
            // TODO: Реализовать Просмотр баланса

            throw new NotImplementedException();
        }
    }
}