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
    }

    public class BaseStock
    {
        public decimal Capitalization { get; set; }
    }
}
