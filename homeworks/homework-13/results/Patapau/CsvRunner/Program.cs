// See https://aka.ms/new-console-template for more information

using CsvRunner;
using Serializer = CsvSerializer.CsvSerializer;
public class Program
{
    public static void Main()
    {
        // 1. Создать набор данных
        List<Stock> Stocks = new List<Stock>() {
            new Stock { Capitalization = 100, CurrentPrice = 5, Ticker = "AAA" },
            new Stock { Capitalization = 200, CurrentPrice = 10, Ticker = "BBB" },
            new Stock { Capitalization = 300, CurrentPrice = 15, Ticker = "CCC" },
            new Stock { Capitalization = 400, CurrentPrice = 20, Ticker = "DDD" },
            new Stock { Capitalization = 500, CurrentPrice = 25, Ticker = "EEE" }
        };


        // 2. Преобразовать в .csv формат
        var resultSerializer = Serializer.Serialize(Stocks);


        // 3. Вывести результат / сохранить в файл
        File.WriteAllText("file.csv", resultSerializer);
        Console.WriteLine(resultSerializer);
    }
}
