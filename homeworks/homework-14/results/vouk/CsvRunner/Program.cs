using System.Data;
using System.Text;
using CsvRunner;
using CsvSerializer;

public class Program
{
    public static void Main()
    {
        List<Stock> list = new List<Stock>();

        list.Add(new Stock
        {
            Name = "Microsoft",
            Ticker = "MSFT",
            Capitalization = 1_000_000_000_000,
            CurrentPrice = 100,
            //Report = new BankReport
            //{
            //    Date = DateTime.Now,
            //    Rating = Rating.Buy
            //},
            //Prices = new decimal[] { 1, 2, 3, 4, 5 }
        });

        list.Add(new Stock
        {
            Name = "Apple",
            Ticker = "AAPL",
            Capitalization = 2_000_000_000_000,
            CurrentPrice = 200,
            //Report = new BankReport
            //{
            //    Date = DateTime.Now,
            //    Rating = Rating.Sell
            //},
            //Prices = new decimal[] { 1, 2, 3, 4, 5 }
        });

        list.Add(new Stock
        {
            Name = "Google",
            Ticker = "GOOG",
            Capitalization = 3_000_000_000_000,
            CurrentPrice = 300,
            //Report = new BankReport
            //{
            //    Date = DateTime.Now,
            //    Rating = Rating.Wait
            //},
            //Prices = new decimal[] { 1, 2, 3, 4, 5 }
        });

        list.Add(new Stock
        {
            Name = "Amazon",
            Ticker = "AMZN",
            Capitalization = 4_000_000_000_000,
            CurrentPrice = 400,
            //Report = new BankReport
            //{
            //    Date = DateTime.Now,
            //    Rating = Rating.Buy
            //},
            //Prices = new decimal[] { 1, 2, 3, 4, 5 }
        });

        CsvSerializerSettings settings = new CsvSerializerSettings
        {
            Delimiter = ";",
            Encoding = Encoding.UTF8,
            HasHeader = true,
            Quote = '"',
            QuoteAllFields = false,
            QuoteNoFields = false,
            QuoteNoSpecialCharacters = false,
            QuoteStringOnly = false,
            SkipEmptyRows = true,
            SkipEmptyRowsStrict = true,
            SkipHeaderRecord = false,
            SkipRecordOnException = true,
            UseSingleLineHeaderInCsv = false
        };

        // Serialize data to CSV file
        string csvSerialized = CsvSerializer<Stock>.Serialize(settings, list);
        string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string strWorkPath = Path.GetDirectoryName(strExeFilePath);
        string strFullPath = Path.Combine(strWorkPath, "stocks.csv");
        File.WriteAllText(strFullPath, csvSerialized);

        // Write data in console
        Console.WriteLine(csvSerialized);

        // Deserialize data from CSV file
        string csvDeserialized = File.ReadAllText(strFullPath);
        Stock[] arrayCollection = CsvSerializer<Stock>.Deserialize(settings, csvDeserialized).ToArray();
    }
}
