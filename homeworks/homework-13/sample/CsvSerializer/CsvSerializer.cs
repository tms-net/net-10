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

            foreach (var property in properties)
            {
                var attr = property.GetCustomAttribute<CsvHeaderAttribute>();
            }

            // 1. Заголовок
            //   - Определить колонки
            //      - Свойства класса
            //      - .......

            

            // 2. Строки
            //   - Получить значения нужных свойств
            //      - форматирование

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