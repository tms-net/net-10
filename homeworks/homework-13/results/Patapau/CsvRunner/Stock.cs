using CsvSerializer;

namespace CsvRunner
{
    [Serializable]
    public class Stock : BaseStock
    {
        private readonly string _name;

        static Stock Empty => new Stock();

        [CsvHeader("Ticker")]
        public string Ticker { get; set; }
        [CsvHeader("Price")]
        public decimal CurrentPrice { get; set; }
    }

    public class BaseStock
    {
        [CsvHeader("Capitalization")]
        public decimal Capitalization { get; set; }
    }
}
