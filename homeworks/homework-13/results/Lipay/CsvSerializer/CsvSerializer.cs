using System.Reflection;
using System.Reflection.PortableExecutable;

namespace CsvSerializer
{
    public class CsvSerializer
    {
        // char == byte
        // ['H','e','l','l']
        public static string Serialize<T>(IEnumerable<T> lines)
        {
            var type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();

            // 1. Заголовок
            //   - Определить колонки
            //      - Свойства класса
            //      - .......
            List<string> namesOfPropertis = new List<string>();
            string propertis;
            foreach (var property in properties)
            {
                var properti = property.Name;
                namesOfPropertis.Add(properti);
            }
            propertis = string.Join(",", namesOfPropertis);
            Console.WriteLine(propertis);


            // 2. Строки
            //   - Получить значения нужных свойств
            //      - форматирование
            //List<string> valueOfProperty = new List<string>();
            //string values;
            //foreach (var property in properties)
            //{
            //    var properti = property.GetValue(property);
               
            //    valueOfProperty.Add(properti.ToString());
            //}
            //values = string.Join(",", valueOfProperty);
            //Console.WriteLine(values);


            var dataLines = from emp in lines
                            let dataLine = string.Join(",", emp.GetType().GetProperties().Select(p => p.GetValue(emp)))
                            select dataLine;
            Console.WriteLine(dataLines);
            return string.Empty;
        }

        public static IEnumerable<T> Deserialize<T>(string csv)
        {
            // 1. Заголовок
            //   - Определить колонки

            // 2. Строки
            //   - Создать объекты
            //   - Получить значение колонки
            //   - Установить значения нужных свойств

            return Enumerable.Empty<T>();
        }
    }
}