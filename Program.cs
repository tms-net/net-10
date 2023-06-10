using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CsvSerializer
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CsvHeaderAttribute : Attribute
    {
        public string Name { get; set; }

        public CsvHeaderAttribute(string name)
        {
            Name = name;
        }
    }

    public static class CsvSerializer
    {
        public static string Serialize<T>(List<T> objects)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            string csv = GenerateCsvHeader(properties);

            foreach (T obj in objects)
            {
                string line = string.Join(",", properties.Select(p => p.GetValue(obj)?.ToString()));
                csv += line + Environment.NewLine;
            }

            return csv;
        }

        public static List<T> Deserialize<T>(string csv)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            ValidateCsvHeader(csv, properties);

            List<T> objects = new List<T>();

            string[] lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines.Skip(1))
            {
                string[] values = line.Split(',');
                T obj = Activator.CreateInstance<T>();

                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = properties[i];
                    object value = Convert.ChangeType(values[i], property.PropertyType);
                    property.SetValue(obj, value);
                }

                objects.Add(obj);
            }

            return objects;
        }

        private static string GenerateCsvHeader(PropertyInfo[] properties)
        {
            string csvHeader = string.Join(",", properties.Select(p =>
            {
                CsvHeaderAttribute headerAttr = p.GetCustomAttribute<CsvHeaderAttribute>();
                return headerAttr != null ? headerAttr.Name : p.Name;
            }));
            csvHeader += Environment.NewLine;

            return csvHeader;
        }

        private static void ValidateCsvHeader(string csv, PropertyInfo[] properties)
        {
            string[] lines = csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string csvHeader = lines.FirstOrDefault();

            if (csvHeader != null)
            {
                string[] headers = csvHeader.Split(',');
                string[] expectedHeaders = properties.Select(p => p.Name).ToArray();

                if (!headers.SequenceEqual(expectedHeaders))
                {
                    throw new Exception("Invalid CSV header.");
                }
            }
        }
    }

    [CsvHeader("Symbol,Price")]
    class Stock
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
    }

    class CsvRunner
    {
        static void Main(string[] args)
        {
            // Создание списка объектов типа Stock
            List<Stock> stocks = new List<Stock>
            {
                new Stock { Symbol = "AAPL", Price = 134.23 },
                new Stock { Symbol = "GOOGL", Price = 2423.56 },
                new Stock { Symbol = "MSFT", Price = 249.73 }
            };

            // Преобразование списка в формат CSV
            string csv = CsvSerializer.Serialize(stocks);

            // Вывод полученного значения
            Console.WriteLine(csv);

            // Сохранение в файл
            string filePath = "stocks.csv";
            File.WriteAllText(filePath, csv);
            Console.WriteLine($"CSV сохранен в файл: {filePath}");

            // Считывание файла или преобразование данных из CSV формата в список объектов
            string csvFromFile = File.ReadAllText(filePath);
            List<Stock> deserializedStocks = CsvSerializer.Deserialize<Stock>(csvFromFile);

            // Вывод значений объектов в консоль
            foreach (Stock stock in deserializedStocks)
            {
                Console.WriteLine($"Symbol: {stock.Symbol}, Price: {stock.Price}");
            }
        }
    }
}
