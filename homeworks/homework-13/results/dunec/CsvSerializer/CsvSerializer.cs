﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

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

            var fileAsString = string.Empty;

            fileAsString = GetHeaderAttribute(properties, lines) + "\r\n";

            fileAsString += GetSCVData(properties, lines);

            return fileAsString;


            //*/

            // 1. Заголовок
            //   - Определить колонки
            //      - Свойства класса
            //      - .......



            // 2. Строки
            //   - Получить значения нужных свойств
            //      - форматирование

            return string.Empty;
        }

        private static void AddCSVElementInLine(ref string file, string line)
        {
            if (file.Equals(string.Empty))
                file = line;
            else
            {
                if (file.EndsWith("\r\n"))
                    file = $"{file}{line}";
                else
                    file = $"{file},{line}";
            }
        }

        private static string GetHeaderAttribute<T>(PropertyInfo[]? properties, IEnumerable<T>? lines, string complexName = "")
        {
            var headerLine = string.Empty;

            foreach (var property in properties)
            {
                var headerName = string.Empty;
                var attr = property.GetCustomAttribute<CsvHeaderAttribute>();
                if (attr != null)
                {
                    if (complexName.Equals(""))
                        headerName = attr.HeaderName;
                    else
                        headerName = $"{complexName}_{attr.HeaderName}";
                }
                else
                {
                    if (complexName.Equals(""))
                        headerName = property.Name;
                    else
                        headerName = $"{complexName}_{property.Name}";
                }
                /*
                if (!property.PropertyType.IsSerializable)
                {
                    AddCSVElementInLine(ref headerLine, GetHeaderAttribute(property.PropertyType.GetProperties(), lines, false, headerName)) ;
                }
                else
                if (property.PropertyType.IsArray)
                {
                    var arrayMax = MaxArrayLenght(lines, property);
                    for (var i = 0; i < arrayMax; i++)
                        AddCSVElementInLine(ref headerLine, $"{headerName}[{i}]");
                }
                else//*/
                    AddCSVElementInLine(ref headerLine, headerName);

                //*/
            }
            return headerLine;
        }

        public static string GetSCVData<T>(PropertyInfo[]? properties, IEnumerable<T>? lines)
        {
            var dataLine = string.Empty;
            foreach (var item in lines)
            {
                foreach (var property in properties)
                {
                    /*
                    if (!property.PropertyType.IsSerializable)
                    {                    
                        AddCSVElementInLine(ref dataLine, GetSCVData(property.PropertyType.GetProperties(), lines, item, false));
                    }
                    else
                    if (property.PropertyType.IsArray)
                    {
                        var array = (Array)property.GetValue(item);
                        foreach (var arrauItem in array)
                        {
                            AddCSVElementInLine(ref dataLine, arrauItem.ToString());
                        }
                        var arrayMax = MaxArrayLenght(lines, property);
                        if (array.Length < arrayMax)
                        {
                            for (var i = array.Length; i < arrayMax; i++)
                            {
                                AddCSVElementInLine(ref dataLine, string.Empty);
                            }
                        }
                    }
                    else
                    {   //*/
                        AddCSVElementInLine(ref dataLine, property.GetValue(item).ToString());
                    //}
                }
                dataLine += "\r\n";
            }
            return dataLine;
        }
        /*
        public static int MaxArrayLenght<T>(IEnumerable<T> lines, PropertyInfo? property)
        {
            var max = 0;
            foreach (var item in lines)
            {
                var length = ((Array)property.GetValue(item)).Length;
                if (length > max)
                    max = length;
            }
            return max;
        }//*/

        public static IEnumerable<T> Deserialize<T>(string csv, CsvSerializerSettings settings = null) where T : new()
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

            var headers = lines[0].Split(",");
            for (var i = 1; i < lines.Length; i++)
            {
                // Проверить заголовок
                var line = lines[i];
                var instance = new T();

                var prop = typeof(T).GetProperties();
                var fields = line.Split(",");
                var numberOfField = 0;
                foreach (var property in prop)
                {
                    /*var isArray = false;
                    do
                    {                        
                        if (property.PropertyType.IsArray)
                        {
                            var massiveName = string.Empty;
                            var attr = property.GetCustomAttribute<CsvHeaderAttribute>();
                            if (attr != null)
                            {
                                massiveName = attr.HeaderName;
                            }
                            else
                            {
                                massiveName = property.Name;
                            }                            
                            var maxMassiveLength = GetMassiveLength(headers, massiveName);
                            int massiveLength = 0;
                            
                            for (var j = numberOfField; j < numberOfField + maxMassiveLength - 1; j++) 
                            {
                                if (!string.IsNullOrEmpty(fields[j]))
                                {
                                    massiveLength++;
                                }                                
                            }

                            string[] obama = new string[massiveLength];

                            var array = Array.CreateInstance(property.PropertyType.GetElementType(), massiveLength);
                            for (var j = 0; j < massiveLength - 1; j++)
                            {
                                if (!string.IsNullOrEmpty(fields[j]))
                                {
                                    obama[j] = fields[j + numberOfField];                                    
                                }
                            }
                            //array = (Array)Convert.ChangeType(obama, property.PropertyType);
                            property.SetValue(instance, array);
                            numberOfField += maxMassiveLength - 1;
                        }
                        else//*/
                    if (property.PropertyType.IsEnum)
                    {          
                        var field = Enum.Parse(property.PropertyType, fields[numberOfField]);
                        property.SetValue(instance, field);
                    }
                    else
                    {
                        var field = Convert.ChangeType(fields[numberOfField], property.PropertyType);
                        property.SetValue(instance, field);
                    }
                    //}
                    //while (isArray);
                    numberOfField++;                   
                }
                /*
                foreach (var field in fields)
                {
                    
                }//*/
                // prop.PropertyType == BankReport

                //var report = Activator.CreateInstance(prop.PropertyType);

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

        private static int GetMassiveLength(string[] fields, string massiveName)
        {
            var length = 0;
            foreach (var field in fields)
            {
                if (field.Contains(massiveName + "["))
                {
                    length++;
                }
            }
            return length;
        }
    }
}