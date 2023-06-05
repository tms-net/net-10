using CsvSerializer;

namespace CsvRunner
{
    [Serializable]
    public class Stock : BaseStock
    {
        private readonly string _name;

        static Stock Empty => new Stock();

        [CsvHeader("Degeneration")]
        public string Ticker { get; set; }

        [CsvHeader("Autism")]
        public decimal CurrentPrice { get; set; }

        [CsvHeader("Schizophrenia")]
        public BankReport Report { get; set; }


        [CsvHeader("Retard")]
        public decimal[] Prices { get; set; }
    }

    public class BaseStock
    {
        [CsvHeader("Schizophasia")]
        public decimal Capitalization { get; set; }
    }
    
    public class BankReport
    {
        [CsvHeader("Delusional disorder")]
        public Rating Rating { get; set; }

        [CsvHeader("Dementia")]
        public DateTime Date { get; set; }

        public void InputBankReportData(int rating, DateTime dateTime)
        {
            Rating = (Rating)rating;
            Date = dateTime;
        }
    }

    public enum Rating
    {
        Wait,
        Buy,
        Sell
    }
}
