namespace Banking
{
    internal class ATM
    {
        private long _cacheAmount;

        public event EventHandler<TransactionEventArgs> TransactionCompleted;

        public ATM(long cashAmount)
        {
            _cacheAmount = cashAmount;
        }

        public bool WithdrawMoney(long amount)
        {
            bool result = false;
            if (amount < 0)
            {
                throw new ArgumentException("Can't withdraw \"negative\" amount of money");
            }

            var args = new TransactionEventArgs();

            if (_cacheAmount >= amount)
            {
                args.TransactionStatus = TransactionStatus.Succeeded;
                args.BalanceBefore = _cacheAmount;

                _cacheAmount -= amount;

                args.BalanceAfter = _cacheAmount;
                result = true;
            }
            else
            {
                args.TransactionStatus = TransactionStatus.Failed;
                args.TransactionError = "Not enough money";
            }

            if (TransactionCompleted != null)
            {
                TransactionCompleted(this, args);
            }
            return result;
        }

        public void TopUpMoney(long amount)
        {
            var args = new TransactionEventArgs();
            if (amount < 0)
            {
                throw new ArgumentException("Can't top up \"negative\" amount of money");
            }

            args.TransactionStatus = TransactionStatus.Succeeded;
            args.BalanceBefore = _cacheAmount;
            _cacheAmount += amount;
            args.BalanceAfter = _cacheAmount;

            if (TransactionCompleted != null)
            {
                TransactionCompleted(this, args);
            }
        }
    }

    public enum TransactionStatus
    {
        Undefuned,
        Succeeded,
        Failed
    }

    public class TransactionEventArgs
    {
        public string? TransactionError { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public long BalanceAfter { get; set; }
        public long BalanceBefore { get; set; }
    }
}
