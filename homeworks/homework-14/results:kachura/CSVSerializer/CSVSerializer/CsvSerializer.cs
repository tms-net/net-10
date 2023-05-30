using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace CSVSerializer
{
    public static class CsvSerializer<TCollection, TElement> where TCollection : IEnumerable<TElement>
    {
        public static string Serialize(TCollection objectToSerialize)
        {
            var propertyInfos = GeneratePropertyInfos();
            var maxLengthProperties = CheckIfArray(propertyInfos, objectToSerialize);

            string header = GenerateHeader(objectToSerialize, propertyInfos, maxLengthProperties);
            string propertyValues = GetData(objectToSerialize, propertyInfos, maxLengthProperties);
            string path = FileManager.SaveString(GetClassName(objectToSerialize), header + "\n" + propertyValues);

            return path;
        }

        public static IEnumerable<TElement> DeSerialize(string path, Type classType)
        {
            string readFileData = FileManager.ReadFile(path);
            string[] lines = readFileData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            string[] linesWithoutHeader = new string[lines.Length - 1];
            Array.Copy(lines, 1, linesWithoutHeader, 0, lines.Length - 1);

            PropertyInfo[] propertyInfo = GeneratePropertyInfos();
            var arrayLength = GetLengthOfProperties(lines[0]);

            foreach (string line in linesWithoutHeader)
            {
                var instance = Activator.CreateInstance(classType);
                string[] values = line.Split(",");

                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    int valueIndex = 0;

                    if (propertyInfo[i].CanWrite)
                    {
                        if (propertyInfo[i].PropertyType.IsArray)
                        {
                            int length = arrayLength[propertyInfo[i].Name];
                            List<object> propertyList = new List<object>();

                            for (int j = 0; j < length; j++)
                            {
                                if (values[i + valueIndex] != string.Empty)
                                {
                                    propertyList.Add(Convert.ChangeType(values[i + valueIndex], propertyInfo[i].PropertyType.GetElementType()));
                                }

                                valueIndex++;
                            }

                            Type elementType = ((Array)propertyInfo[i].GetValue(instance)).GetType().GetElementType();
                            Array resultArray = Array.CreateInstance(elementType, propertyList.ToArray().Length);
                            propertyList.ToArray().CopyTo(resultArray, 0);
                            propertyInfo[i].SetValue(instance, resultArray);
                        }
                        else
                        {
                            var value = Convert.ChangeType(values[i + valueIndex], propertyInfo[i].PropertyType);
                            propertyInfo[i].SetValue(instance, value);
                        }
                    }
                }

                yield return (TElement)instance;
            }
        }

        //based on header dictionary contains how many items of the same name is presented in the file (made for arrays)
        private static Dictionary<string, int> GetLengthOfProperties(string header)
        {
            var lengthOfProperties = new Dictionary<string, int>();
            string[] names = header.Split(",");

            foreach (string name in names)
            {
                if (name.Contains("_"))
                {
                    string nameOfProperty = name.Split("_")[0];

                    if (lengthOfProperties.ContainsKey(nameOfProperty))
                    {
                        lengthOfProperties[nameOfProperty]++;
                    }
                    else
                    {
                        lengthOfProperties.Add(nameOfProperty, 1);
                    }
                }
            }

            return lengthOfProperties;
        }

        //generate header based on names of properties, separated by ","
        private static string GenerateHeader(TCollection objectToSerialize, PropertyInfo[] propertyInfos, Dictionary<PropertyInfo, int> maxLength)
        {
            string propertyiesNames = string.Empty;

            foreach (var propertyInfo in propertyInfos)
            {

                if (!maxLength.ContainsKey(propertyInfo))
                {
                    propertyiesNames += propertyInfo.Name + ",";
                }
                else
                {
                    for (int i = 0; i < maxLength[propertyInfo]; i++)
                    {
                        propertyiesNames += propertyInfo.Name + $"_{i},";
                    }
                }
            }

            propertyiesNames = propertyiesNames.Remove(propertyiesNames.Length - 1);

            return propertyiesNames;
        }

        //prepare string of values ready for CSV
        private static string GetData(TCollection objectToSerialize, PropertyInfo[] propertyInfos, Dictionary<PropertyInfo, int> maxLength)
        {
            string propertyValues = string.Empty;

            foreach (var curObject in objectToSerialize)
            {
                foreach (var propertyInfo in propertyInfos)
                {
                    if (!maxLength.ContainsKey(propertyInfo)) //if property non-array
                    {
                        propertyValues += propertyInfo.GetValue(curObject) + ",";
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.IsArray)
                        {
                            propertyValues += PrepareArrayData(propertyInfo, curObject, maxLength[propertyInfo]);
                        }
                    }
                }

                propertyValues = propertyValues.Remove(propertyValues.Length - 1) + "\n";
            }

            return propertyValues;
        }

        //get data from propertyInfo if the Type is Array
        private static string PrepareArrayData(PropertyInfo propertyInfo, TElement curObject, int maxLength)
        {
            Array array = (Array)propertyInfo.GetValue(curObject);
            int counter = 0;
            string preparedArrayData = string.Empty;

            foreach (object element in array)
            {
                preparedArrayData += element + ",";
                counter++;
            }

            if (counter < maxLength)
            {
                for (int i = counter; i < maxLength; i++)
                {
                    preparedArrayData += ",";
                }
            }
            return preparedArrayData;
        }

        private static string GetClassName(TCollection objectToSerialize)
        {
            string className = objectToSerialize.First().GetType().Name ?? DateTime.Now.ToString();

            return className;
        }

        //generate property info based on generic type
        private static PropertyInfo[] GeneratePropertyInfos()
        {
            Type typeOfObject = typeof(TElement);
            var propertyInfos = typeOfObject.GetProperties();

            return propertyInfos;
        }

        private static Dictionary<PropertyInfo, int> CheckIfArray(PropertyInfo[] propertyInfos, TCollection objectToSerialize)
        {
            Dictionary<PropertyInfo, int> maxArrayLength = new Dictionary<PropertyInfo, int>();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;

                if (propertyType.IsArray)
                {
                    foreach (var element in objectToSerialize)
                    {
                        if (element != null)
                        {
                            Array array = (Array)propertyInfo.GetValue(element);
                            int length = array.Length;

                            if (!maxArrayLength.ContainsKey(propertyInfo))
                            {
                                maxArrayLength.Add(propertyInfo, length);
                            }
                            else if ((maxArrayLength.ContainsKey(propertyInfo) && maxArrayLength[propertyInfo] < length))
                            {
                                maxArrayLength[propertyInfo] = length;
                            }
                        }
                    }
                }             
            }

            return maxArrayLength;
        }
    }
}