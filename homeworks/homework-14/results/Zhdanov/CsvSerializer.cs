using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CcvSerializer;
using CsvSerializer.Example;

namespace CsvSerializer
{
    public class CsvSerializer
    {
        public static string Serialize<T>(List<T> objects)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            var header = GetCsvHeader(properties);

            var lines = new List<string> { header };

            foreach (var obj in objects)
            {
                var values = properties.Select(p => p.GetValue(obj)?.ToString() ?? string.Empty);
                var line = string.Join(",", values);
                lines.Add(line);
            }

            return string.Join(Environment.NewLine, lines);
        }

        public static List<T> Deserialize<T>(string csvData)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            var header = GetCsvHeader(properties);
            var lines = csvData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length <= 1)
            {
                return new List<T>();
            }

            if (!string.Equals(lines[0], header, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Invalid csv data format.");
            }

            var objects = new List<T>();

            for (var i = 1; i < lines.Length; i++)
            {
                var fields = lines[i].Split(',');

                if (fields.Length != properties.Length)
                {
                    throw new Exception("Invalid csv data format.");
                }

                var obj = Activator.CreateInstance<T>();

                for (var j = 0; j < fields.Length; j++)
                {
                    var property = properties[j];
                    var value = Convert.ChangeType(fields[j], property.PropertyType);
                    property.SetValue(obj, value);
                }

                objects.Add(obj);
            }

            return objects;
        }

        private static string GetCsvHeader(PropertyInfo[] properties)
        {
            var attribute = properties[0].GetCustomAttribute<CsvHeaderAttribute>();

            if (attribute != null)
            {
                return attribute.Header;
            }

            var header = string.Join(",", properties.Select(p => p.Name));
            return header;
        }
    }
}
