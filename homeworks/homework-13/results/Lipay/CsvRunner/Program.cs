// See https://aka.ms/new-console-template for more information

using CsvRunner;

public class Program
{
    public static void Main()
    {
        // 1. Создать набор данных
        var CompanyStock = new List<Stock> { 
            new Stock{ Capitalization = 1000, CurrentPrice = 100, Ticker = "MSFT"}, 
            new Stock{ Capitalization = 10000, CurrentPrice = 100, Ticker = "AAPL"}, 
            new Stock{ Capitalization = 50000, CurrentPrice = 200, Ticker = "AMZN"},
        };
        // 2. Преобразовать в .csv формат
        string headerLine = string.Join(",",CompanyStock[0].GetType().GetProperties().Select(p => p.Name));

        var dataLines = from emp in CompanyStock
                        let dataLine = string.Join(",", emp.GetType().GetProperties().Select(p => p.GetValue(emp)))
                        select dataLine;
        var csvData = new List<string>();
        csvData.Add(headerLine);
        csvData.AddRange(dataLines);

        string csvFilePath = @"D:\Visual Studio\newFile.csv";
        File.WriteAllLines(csvFilePath, csvData);
        Console.WriteLine(csvData);
        Console.ReadLine();
        // 3. Вывести результат / сохранить в файл

    }
}
