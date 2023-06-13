using CsvSerializer;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        /*
        [CsvHeader("Dissociative identity disorder")] 
        public BankReport Report { get; set; }//*/


        [CsvHeader("Schizophrenia")]
        public decimal[] Prices { get; set; }

        public void InputStockData(string ticker, decimal currentPrice, int rating, DateTime dateTime, decimal[] prices, decimal capitalization)
        {
            Ticker = ticker;
            CurrentPrice = currentPrice;/*
            Report = new BankReport();
            Report.InputBankReportData(rating, dateTime);//*/
            Prices = prices;
            Capitalization = capitalization;
        }

        public override string ToString()
        {
            var prices = string.Empty;
            foreach (var price in Prices)
                prices += price.ToString();
            return $"Ticker: {Ticker}, CurrentPrice: {CurrentPrice}, []Prices: {prices}, Capitalization: {Capitalization} \n";
        }
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
