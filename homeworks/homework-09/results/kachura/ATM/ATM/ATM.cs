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

        public void WithdrawMoney(long amount)
        {
            var args = new TransactionEventArgs();

            if (_cacheAmount >= amount)
            {
                args.TransactionStatus = TransactionStatus.Succeeded;
                args.BalanceBefore = _cacheAmount;

                _cacheAmount -= amount;

                args.BalanceAfter = _cacheAmount;
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
        }

        public void TopUpMoney(long amount)
        {
            var args = new TransactionEventArgs();

            if (amount > 0)
            {
                args.BalanceAfter += amount;

                _cacheAmount += amount;
                args.TransactionStatus = TransactionStatus.Succeeded;
            }
            else
            {
                args.TransactionStatus = TransactionStatus.Failed;
                args.TransactionError = "Invalid amount";
            }

            if(TransactionCompleted != null)
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
        public string TransactionError { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public long BalanceAfter { get; set; }
        public long BalanceBefore { get; set; }
    }
}
