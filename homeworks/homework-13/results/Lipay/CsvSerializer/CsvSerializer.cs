using System.Reflection;

namespace CsvSerializer
{
    public class CsvSerializer
    {
        // char == byte
        // ['H','e','l','l']
        public static string Serialize<T>(IEnumerable<T> lines)
        {
            var type = typeof(T);


            var properties = type.GetProperties();

            List<string> namesOfPropertis = new List<string>();
            string propertis;
            foreach (var property in properties)
            {
                var properti = property.Name;
                namesOfPropertis.Add(properti);
            }
            propertis = string.Join(",", namesOfPropertis);
            Console.WriteLine(propertis);


            // 1. Заголовок
            //   - Определить колонки
            //      - Свойства класса
            //      - .......



            // 2. Строки
            //   - Получить значения нужных свойств
            //      - форматирование

            foreach (var property in properties)
            {
                
            }


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