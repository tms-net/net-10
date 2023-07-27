// See https://aka.ms/new-console-template for more information

using CsvRunner;

public class Program
{
    public static void Main()
    {
        string file = string.Empty;
        Random random = new Random();

        var list = new List<Stock>();

        for (int i = 0; i < random.Next(10) + 1; i++) 
        {
            var stock = new Stock();/*
            var prices = new decimal[random.Next(10)];
            for (int j = 0; j < prices.Length; j++) 
            {
                prices[j] = (decimal)(random.Next(5) + random.NextDouble());
            }//*/
            stock.InputStockData(RandomWord(random.Next(3)), 
                                            (decimal)(random.Next(6) + random.NextDouble()), 
                                            random.Next(3), 
                                            DateTime.Now.AddDays(random.Next(11)-random.Next(10)), //prices, 
                                            (decimal)(random.Next(6) + random.NextDouble()),
                                            random.Next(11));
            list.Add(stock);
        }
       
        file = CsvSerializer.CsvSerializer.Serialize<Stock>(list);
        Console.WriteLine(file);
        File.WriteAllText(Directory.GetCurrentDirectory() + "\\data.csv", file);

        Console.ReadLine();
        file = string.Empty;
        file = File.ReadAllText(Directory.GetCurrentDirectory() + "\\data.csv");
        Console.WriteLine(file);
        Console.WriteLine();
        var list2 = CsvSerializer.CsvSerializer.Deserialize<Stock>(file);
        
        foreach (var stock in list2)
        {
            Console.WriteLine(stock.ToString());
        }
        
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
