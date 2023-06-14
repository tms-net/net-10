using CsvSerializer;

namespace CsvRunner
{
    [Serializable]
    public class Stock : BaseStock
    {
        private readonly string _name;

        static Stock Empty => new Stock();

        [CsvHeader("символ")]
        public string Ticker { get; set; }
        
        public decimal CurrentPrice { get; set; }

        public BankReport Report { get; set; }

        public decimal[] Prices { get; set; }
    }

    public class BaseStock
    {
        public decimal Capitalization { get; set; }
    }
    
    public class BankReport
    {
        public Rating Rating { get; set; }
        public DateTime Date { get; set; }
    }

    public enum Rating
    {
        Wait,
        Buy,
        Sell
    }
}
