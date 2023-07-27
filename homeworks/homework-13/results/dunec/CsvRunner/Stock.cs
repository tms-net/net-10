using CsvSerializer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CsvRunner
{
    [Serializable]
    public class Stock : BaseStock
    {
        private readonly string _name;

        static Stock Empty => new Stock();

        [CsvHeader("Ticker")]
        public string Ticker { get; set; }

        [CsvHeader("CurrentPrice")]
        public decimal CurrentPrice { get; set; }

        public int JustNumber { get; set; }

        public DateTime SomeDate { get; set; }
        
        [CsvHeader("Rating")]
        public Rating Rating { get; set; }//*/
        /*
        [CsvHeader("Dissociative identity disorder")] 
        public BankReport Report { get; set; }//*/

        /*
        [CsvHeader("Prices")]
        public decimal[] Prices { get; set; }//*/

        public void InputStockData(string ticker, decimal currentPrice, int rating, DateTime dateTime,/* decimal[] prices,*/ decimal capitalization, int number)
        {
            Ticker = ticker;
            JustNumber = number;
            SomeDate = dateTime;
            Rating = (Rating)rating;
            CurrentPrice = currentPrice;/*
            Report = new BankReport();
            Report.InputBankReportData(rating, dateTime);
            Prices = prices;//*/
            Capitalization = capitalization;
        }

        public override string ToString()
        {/*
            var prices = string.Empty;
            foreach (var price in Prices)
                prices += price.ToString();//*/
            return $"Ticker: {Ticker}, CurrentPrice: {CurrentPrice}, JustNumber: {JustNumber}, Somedate: {SomeDate}, Capitalization: {Capitalization}, Rating: {Rating}";
        }
    }

    public class BaseStock
    {
        [CsvHeader("Capitalization")]
        public decimal Capitalization { get; set; }
    }
    
    public class BankReport
    {
        [CsvHeader("Rating")]
        public Rating Rating { get; set; }

        [CsvHeader("Date")]
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
