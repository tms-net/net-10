namespace Banking
{
    public interface ITransaction
    {
        event EventHandler<TransactionEventArgs> TransactionCompleted;
    }

    public delegate bool MyDelegate(long id);

    internal class ATM : ITransaction
    {
        private long _cacheAmount;

        public MyDelegate Started;

        private string _name;
        public string Name
        {
            get => _name;
            set =>_name = value;
        }

        private EventHandler<TransactionEventArgs> _transactionCompleted;

        event EventHandler<TransactionEventArgs> ITransaction.TransactionCompleted
        {
            add => _transactionCompleted += value;
            remove => _transactionCompleted -= value;
        }

        public ATM(long cashAmount)
        {
            _cacheAmount = cashAmount;
        }

        public static void MyDelegateImpl(long amount)
        {

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
                //_transactionCompleted?.Invoke(this, args);
                _transactionCompleted(this, args);
            }
        }

        public void TopUpMoney(long amount)
        {
            // TODO: Реализовать пополнение средств

            throw new NotImplementedException();
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
