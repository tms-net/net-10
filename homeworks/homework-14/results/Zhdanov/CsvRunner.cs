using System;
using System.Collections.Generic;
using System.IO;
using CsvSerializer.Example;

namespace CsvRunner
{
    public class CsvRunner
    {
        public static void Main()
        {
            var stocks = new List<Stock>
            {
                new Stock { Symbol = "AAPL", Price = 150.25m, Volume = 1000 },
                new Stock { Symbol = "GOOGL", Price = 2500.75m, Volume = 500 },
                new Stock { Symbol = "MSFT", Price = 300.50m, Volume = 750 }
            };

            var csvData = CsvSerializer.CsvSerializer.Serialize(stocks);
            Console.WriteLine(csvData);

            File.WriteAllText("stocks.csv", csvData);

            var csvDataFromFile = File.ReadAllText("stocks.csv");
            var stocksFromFile = CsvSerializer.CsvSerializer.Deserialize<Stock>(csvDataFromFile);

            foreach (var stock in stocksFromFile)
            {
                Console.WriteLine($"Symbol: {stock.Symbol}, Price: {stock.Price}, Volume: {stock.Volume}");
            }
        }
    }
}








