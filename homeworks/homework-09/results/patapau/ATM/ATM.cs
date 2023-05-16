namespace Banking
{

    internal class ATM 
    {
        private long _cacheAmount;

        public event EventHandler<TransactionEventArgs> _transactionCompleted;

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

            if (_transactionCompleted != null)
            {
                _transactionCompleted(this, args);
            }
        }

        public void TopUpMoney(long amount)
        {
            var args = new TransactionEventArgs();

            if (amount > 0 ) 
            {
                args.TransactionStatus = TransactionStatus.Succeeded;
                args.BalanceBefore = _cacheAmount;
                _cacheAmount += amount;
                args.BalanceAfter = _cacheAmount;
            }
            else
            {
                args.TransactionStatus = TransactionStatus.Failed;
                args.TransactionError = "Top-up amount is less than 1";
            }

            if (_transactionCompleted != null)
            {
                _transactionCompleted(this, args);
            }
        }
    }

    public enum TransactionStatus
    {
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
