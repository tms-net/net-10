using System.Runtime.Serialization;

namespace CsvRunner
{
    [Serializable]
    public class Stock : BaseStock
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        //[DataMember(Name = "Ticker", Order = 2)]
        public string Ticker { get; set; }

        [DataMember(Name = "Report", Order = 4)]
        public BankReport Report { get; set; }

        [DataMember(Name = "CurrentPrice", Order = 3)]
        public decimal CurrentPrice { get; set; }

        //[DataMember(Name = "Prices", Order = 4)]
        public IEnumerable<decimal> Prices { get; set; }
    }

    [Serializable]
    public class BaseStock
    {
        //[DataMember(Name = "Capitalization", Order = 6)]
        public decimal Capitalization { get; set; }
    }

    [Serializable]
    public class BankReport
    {
        [DataMember(Name = "Rating", Order = 7)]
        public Rating Rating { get; set; }

        [DataMember(Name = "Date", Order = 8)]
        public BankInfo Bank { get; set; }

        //[DataMember(Name = "Date", Order = 8)]
        public DateTime Date { get; set; }
    }

    public class BankInfo
    {
        [DataMember(Name = "Date", Order = 10)]
        public string Name { get; set; }
    }

    public enum Rating
    {
        Wait,
        Buy,
        Sell
    }
}
