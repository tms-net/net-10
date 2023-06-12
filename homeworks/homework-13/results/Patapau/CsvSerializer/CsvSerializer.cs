using System.Reflection;



namespace CsvSerializer
{
    public class CsvSerializer
    {
        //private static string nameAttr = string.Empty;
        public static string Serialize<T>(IEnumerable<T> lines)
        {
            var type = typeof(T);

            string results = string.Empty;

            var listTemp = new List<string>();

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attr = property.GetCustomAttribute<CsvHeaderAttribute>();
                if (attr != null)
                {
                    listTemp.Add(attr.HeaderName);
                }
            }
            AddNewString();


            foreach (var line in lines)
            {
                foreach (var property in properties)
                {
                    listTemp.Add(property.GetValue(line).ToString());
                }
                AddNewString();
            }
            return results;

            void AddNewString()
            {
                results += string.Join(",", listTemp);
                results += "\n";
                listTemp.Clear();
            }
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