using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;


namespace CSVSerializer
{
    public static class CsvSerializer<TCollection, TElement> where TCollection : IEnumerable<TElement>
    {
        private static PropertyInfo[] _propertyInfos;

        public static string Serialize(TCollection objectToSerialize)
        {
            GeneratePropertyInfos();
            var maxLengthProperties = CheckIfCollection(_propertyInfos, objectToSerialize);

            string header = GenerateHeader(objectToSerialize, maxLengthProperties);
            string propertyValues = GetData(objectToSerialize, maxLengthProperties);
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
            var arrayAndCollectionLength = GetLengthOfProperties(lines[0]);

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
                            int length = arrayAndCollectionLength[propertyInfo[i].Name];
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

                        else if (propertyInfo[i].PropertyType.GetInterface("IEnumerable") != null && propertyInfo[i].PropertyType != typeof(string))
                        {
                           
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

        //based on header dictionary contains how many items of the same name is presented in the file (made for arrays and collections)
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
        private static string GenerateHeader(TCollection objectToSerialize, Dictionary<PropertyInfo, int> maxLength)
        {
            string propertyiesNames = string.Empty;

            foreach (var propertyInfo in _propertyInfos)
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

        //prepares string of values ready for CSV
        private static string GetData(TCollection objectToSerialize, Dictionary<PropertyInfo, int> maxLength)
        {
            string propertyValues = string.Empty;

            foreach (var curObject in objectToSerialize)
            {
                foreach (var propertyInfo in _propertyInfos)
                {
                    if (!maxLength.ContainsKey(propertyInfo)) //if property non-array and non-collection type
                    {
                        propertyValues += propertyInfo.GetValue(curObject) + ",";
                    }
                    else
                    {
                        if (propertyInfo.PropertyType.IsArray)
                        {
                            Array array = (Array)propertyInfo.GetValue(curObject);
                            int counter = 0;

                            foreach (object element in array)
                            {
                                propertyValues += element + ",";
                                counter++;
                            }

                            if (counter < maxLength[propertyInfo])
                            {
                                for (int i = counter; i < maxLength[propertyInfo]; i++)
                                {
                                    propertyValues += ",";
                                }
                            }
                        }
                        else
                        {
                            var collectionTemp = (System.Collections.IEnumerable)propertyInfo.GetValue(curObject);
                            var collection = collectionTemp.Cast<object>();
                            int counter = 0;

                            if (collection != null)
                            {
                                foreach (object element in collection)
                                {
                                    propertyValues += element + ",";
                                    counter++;
                                }
                            }

                            if (counter < maxLength[propertyInfo])
                            {
                                for (int i = counter; i < maxLength[propertyInfo]; i++)
                                {
                                    propertyValues += ",";
                                }
                            }

                        }

                    }
                }

                propertyValues = propertyValues.Remove(propertyValues.Length - 1) + "\n";
            }

            return propertyValues;
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

            _propertyInfos = typeOfObject.GetProperties();

            return _propertyInfos;
        }

        private static Dictionary<PropertyInfo, int> CheckIfCollection(PropertyInfo[] propertyInfos, TCollection objectToSerialize)
        {
            Dictionary<PropertyInfo, int> maxCollectionLength = new Dictionary<PropertyInfo, int>();

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

                            if (!maxCollectionLength.ContainsKey(propertyInfo))
                            {
                                maxCollectionLength.Add(propertyInfo, length);
                            }
                            else if ((maxCollectionLength.ContainsKey(propertyInfo) && maxCollectionLength[propertyInfo] < length))
                            {
                                maxCollectionLength[propertyInfo] = length;
                            }
                        }
                    }
                }
                else if (propertyType.GetInterface("IEnumerable") != null && propertyType != typeof(string))
                {
                    foreach (var element in objectToSerialize)
                    {
                        if (element != null)
                        {
                            var collectionTemp = (System.Collections.IEnumerable)propertyInfo.GetValue(element);
                            var collection = collectionTemp.Cast<object>();

                            int length = 0;

                            if (collection != null)
                            {
                                length = collection.Count();
                            }

                            if (!maxCollectionLength.ContainsKey(propertyInfo))
                            {
                                maxCollectionLength.Add(propertyInfo, length);
                            }
                            else if ((maxCollectionLength.ContainsKey(propertyInfo) && maxCollectionLength[propertyInfo] < length))
                            {
                                maxCollectionLength[propertyInfo] = length;
                            }
                        }
                    }
                }
            }

            return maxCollectionLength;
        }
    }
}



