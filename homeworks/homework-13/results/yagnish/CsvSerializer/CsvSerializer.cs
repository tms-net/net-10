using System.Reflection;

namespace CsvSerializer
{
    // Итеративный метод
    //  - Обратная связь (CsvRunner)
    //  - Критерии
    //    - Качество кода:
    //      1. Работает
    //      2. Производительность (алгоритмическая сложность, память, загрузка процессора)
    //      3. Читаемость
    //      4. Обслуживаемость (расширяемость, легкость внесения изменений), масштабируемость
    //      5. Измеряемость

    public class CsvSerializer
    {
        // char == byte
        // ['H','e','l','l','o']
        public static string Serialize<T>(IEnumerable<T> lines, CsvSerializerSettings settings = null)
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

        public static IEnumerable<T> Deserialize<T>(string csv, CsvSerializerSettings settings = null) where T: new()
        {
            // [char (byte), char]

            //foreach (var ch in csv)
            //{
            //    if (ch == '\r' || ch == '\n')
            //    {                    
            //        Environment.NewLine;
            //        // Environment.NewLine -> Linux "\n", Win "\r\n"
            //    }
            //}

            string[] lines = csv.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                // Проверить заголовок

                var instance = new T();

                var prop = typeof(T).GetProperty("Report");
                // prop.PropertyType == BankReport

                var report = Activator.CreateInstance(prop.PropertyType);

                // Заполнить свойства
                //  - возможно надо создавать другие объекты

                yield return instance;
            }

            // 1. Заголовок
            //   - Определить колонки

            // 2. Строки
            //   - Создать объекты
            //   - Получить значение колонки
            //   - Установить значения нужных свойств

            yield break;
        }
    }
}