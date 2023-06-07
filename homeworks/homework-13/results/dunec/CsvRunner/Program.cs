// See https://aka.ms/new-console-template for more information

using CsvRunner;

public class Program
{
    public static void Main()
    {
        string file = string.Empty;
        Random random = new Random();

        var list = new List<Stock>();

        for (int i = 0; i < random.Next(10); i++) 
        {
            var stock = new Stock();
            var prices = new decimal[random.Next(10)];
            for (int j = 0; j < prices.Length; j++) 
            {
                prices[j] = (decimal)(random.Next(5) + random.NextDouble());
            }
            stock.InputStockData(RandomWord(random.Next(2)), 
                                            (decimal)(random.Next(5) + random.NextDouble()), 
                                            random.Next(10), 
                                            DateTime.Now.AddDays(random.Next(10)-random.Next(10)), prices, 
                                            (decimal)(random.Next(5) + random.NextDouble()));
            list.Add(stock);
        }
       
        file = CsvSerializer.CsvSerializer.Serialize<Stock>(list);
        Console.WriteLine(file);
        File.WriteAllText(Directory.GetCurrentDirectory() + "\\data.csv", file);

        Console.ReadLine();
    }


    public static string RandomWord(int random)
    {
        switch (random)
        {
            case 0: return "ABOBA";
            case 1: return "jeOVER";
            case 2: return "biDONE";
            default: return string.Empty;
        }        
    }
}
