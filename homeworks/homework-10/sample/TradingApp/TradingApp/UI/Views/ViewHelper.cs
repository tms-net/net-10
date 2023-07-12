namespace TradingApp.UI.Views
{
    internal class ViewHelper
    {
        internal static string GetSymbolFromConsole(string title)
        {
            string result;

            while (true)
            {
                Console.WriteLine(title);
                result = Console.ReadLine();
                if (result == null || result.Length == 0)
                {
                    Console.WriteLine($"Incorrect Symbol name {result}");
                }
                else
                {
                    return result;
                }
            }
        }

        internal static TimeSpan GetTimeSpanFromConsole()
        {
            while (true)
            {
                Console.WriteLine("Input date FROM: ");
                if (!DateTime.TryParse(Console.ReadLine(), out var dateTimeFrom))
                {
                    Console.WriteLine($"Uncorrect date {dateTimeFrom}");
                }
                else
                {
                    continue;
                }
                    
                return DateTime.UtcNow - dateTimeFrom;
            }
        }

        internal static TimeSpan GetGranularityFromConsole()
        {
            while (true)
            {
                Console.WriteLine("For retrieving info choose granularity (1 - 5min, 2 - 30min, 3 - 1hiur, 4 - Day)");
                switch (Console.ReadLine())
                {
                    case "1": return TimeSpan.FromMinutes(5);
                    case "2": return TimeSpan.FromMinutes(30);
                    case "3": return TimeSpan.FromHours(1);
                    case "4": return TimeSpan.FromDays(1);
                    default: Console.WriteLine("Unavailable granularity code"); break;
                }
            }
        }

        public static int GetNumberFromConsole(params int[] values)
        {
            while (true)
            {
                var ch = Console.ReadKey();

                if (char.IsNumber(ch.KeyChar))
                {
                    var number = int.Parse(ch.ToString());

                    if (values.Contains(number))
                    {
                        return number;
                    }
                }
                
                Console.WriteLine("Enter correct number");                
            }
        }
    }
}
