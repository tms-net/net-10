using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace CsvSerializer
{
    namespace Serialization
    {
        public abstract class CsvSerializerAbstraction<TEntity>
            where TEntity : class
        {
            protected internal readonly string _csvSeparator;

            protected internal static string CsvSeparator { get; private set; }

            public CsvSerializerAbstraction(CsvSerializerSettings csvSerializerSettings)
            {
                this._csvSeparator = csvSerializerSettings.Delimiter;
                CsvSeparator = this._csvSeparator.ToString();
            }
        }

        // Создание объектов сериализатора
        // вызов внутренних методов
        public sealed class CsvSerializer //: CsvSerializerAbstraction<DataRow>
        {
            public static string Serialize<TEntity>(CsvSerializerSettings csvSerializerSettings, List<TEntity> collection)
                where TEntity : class
            {
                // ADO.NET

                // Table
                //  - Scheme
                // DataRow

                var serializer = new CsvSerializer<TEntity>(csvSerializerSettings);

                return serializer.Serialize(collection.ToArray());
            }

            public static List<TEntity> Deserialize<TEntity>(CsvSerializerSettings csvSerializerSettings, string collection)
                where TEntity : class
            {
                var serializer = new CsvSerializer<TEntity>(csvSerializerSettings);
                return serializer.Deserialize(collection).ToList();
            }
        }

        internal sealed class CsvSerializer<TEntity> : CsvSerializerAbstraction<TEntity>
            where TEntity : class
        {
            private readonly CsvSerializerSettings _csvSerializerSettings;
            private readonly NTree<ClassProperty> _propertyTree;

            internal CsvSerializer() : this(new CsvSerializerSettings())
            {
            }

            internal CsvSerializer(CsvSerializerSettings csvSerializerSettings) : base(csvSerializerSettings)
            {
                _csvSerializerSettings = csvSerializerSettings;
                _propertyTree = PropertyTreeBuilder.BuildPropertyTree(typeof(TEntity));
            }

            protected internal string Serialize(params TEntity[] collection)
            {
                StringBuilder sbColumns = new StringBuilder();
                StringBuilder sbRows = new StringBuilder();

                KeyValuePair<PropertyInfo, DataMemberAttribute>[] pairs
                    = typeof(TEntity).GetProperties()
                        .Select(x => new KeyValuePair<PropertyInfo, DataMemberAttribute>(x, (DataMemberAttribute)x.GetCustomAttribute(typeof(DataMemberAttribute))))
                        .ToArray();

                this.MountCsvColumns(ref sbColumns, pairs);

                for (int j = 0; j < collection.Length; j++)
                {
                    this.MountCsvRows(ref sbRows, collection[j], pairs);
                }
                return sbColumns.ToString() + sbRows.ToString();
            }

            protected internal IEnumerable<TEntity> Deserialize(string csvString)
            {
                string[] arrayLinesCsv = csvString.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                string[] columnsName = arrayLinesCsv[0].Split(_csvSerializerSettings.Delimiter);

                Type tp = typeof(TEntity);

                PropertyInfo[] props = tp.GetProperties();

                var propMapping = GetPropertyMapping();

                //if (propMapping.Count < columnsName.Length)
                //{
                //    MapArrayColumns(propMapping.Count);
                //}

                // header => setValue(value)

                for (int i = 1; i < arrayLinesCsv.Length; i++)
                {
                    var propInstances = new Dictionary<PropertyInfo, object>();
                    var instance = Activator.CreateInstance<TEntity>();

                    string[] columnsValues = arrayLinesCsv[i].Split(_csvSerializerSettings.Delimiter);
                    var deserializationVisitor = new DeserializationVisitor(instance, columnsValues);

                    _propertyTree.TraversePropertyTreeDFS(deserializationVisitor);

                    // props.Count == columnsValue.Count

                    // Validate row entry

                    for (int j = 0; j < propMapping.Count; j++)
                    {
                        var prop = propMapping[j];
                        prop.SetProperty(instance, columnsValues[j]);
                    }

                    yield return instance;
                }
            }

            private List<PropertyMapping> GetPropertyMapping()
            {
                var list = new List<PropertyMapping>();
                GetPropertyMapping(list, typeof(TEntity));
                return list;
            }

            private void GetPropertyMapping(
                List<PropertyMapping> propMapping,
                Type type,
                PropertyMapping parentProperty = null)
            {
                object GetInstance(PropertyMapping property, object rootInstance)
                {
                    if (property == null)
                    {
                        return rootInstance;
                    }

                    var instance = GetInstance(property.ParentProperty, rootInstance);
                    var propValue = property.PropertyInfo.GetValue(instance);
                    if (propValue == null)
                    {
                        propValue = Activator.CreateInstance(property.PropertyInfo.PropertyType);
                        property.PropertyInfo.SetValue(instance, propValue);
                    }

                    return propValue;
                }

                PropertyInfo[] props = type.GetProperties();
                for (int i = 0; i < props.Length; i++)
                {
                    var prop = props[i];
                    DataMemberAttribute att = prop.GetCustomAttribute<DataMemberAttribute>();
                    if (att != null)
                    {
                        switch (prop.PropertyType)
                        {
                            case var stringType when stringType == typeof(string):
                                propMapping.Add(new PropertyMapping
                                {
                                    SetProperty = (rootInstance, value) => prop.SetValue(GetInstance(parentProperty, rootInstance), value.ToString(), null),
                                    ParentProperty = parentProperty,
                                    PropertyInfo = prop
                                });
                                break;

                            case var enumType when enumType.IsEnum:
                                propMapping.Add(new PropertyMapping
                                {
                                    SetProperty = (rootInstance, value) => prop.SetValue(GetInstance(parentProperty, rootInstance), Enum.Parse(enumType, value.ToString()), null),
                                    ParentProperty = parentProperty,
                                    PropertyInfo = prop
                                });
                                break;

                            // посмотрели все свойства и засетили примитивные
                            case var primitivetype when primitivetype.IsValueType || primitivetype.IsPrimitive:
                                propMapping.Add(new PropertyMapping
                                {
                                    SetProperty = (rootInstance, value) => prop.SetValue(GetInstance(parentProperty, rootInstance), Convert.ChangeType(value, Type.GetTypeCode(primitivetype)), null),
                                    ParentProperty = parentProperty,
                                    PropertyInfo = prop
                                });
                                break;

                            case var refType when !refType.IsValueType:
                                // Create instance of Property Type
                                // Set fields
                                GetPropertyMapping(propMapping, refType, new PropertyMapping
                                {
                                    ParentProperty = parentProperty,
                                    PropertyInfo = prop,
                                    SetProperty = (instance, value) => throw new NotSupportedException()
                                });
                                break;

                                //IEnumerable<string> en;
                                //List<string> list;
                                //en = list;


                                //bool IsCollection(Type t)
                                //{
                                //    var genType = typeof(IEnumerable<>);
                                //     if (t.IsGenericType)
                                //     {
                                //        var types = t.GetGenericArguments();
                                //        genType.MakeGenericType(genType);
                                //     }

                                //    return t.IsAssignableTo(genType);
                                //}

                                //case var arrayType when IsCollection(arrayType)//.IsAssignableTo():
                                //    // Create instance of Property Type
                                //    // Set fields
                                //    GetPropertyMapping(propMapping, refType);
                                //    break;
                        }
                    }
                }
            }

            private void MountCsvColumns(ref StringBuilder sbColumns, params KeyValuePair<PropertyInfo, DataMemberAttribute>[] pairs)
            {
                for (int i = 0; i < pairs.Length; i++)
                {
                    if (i == pairs.Length - 1)
                    {
                        sbColumns.AppendLine(pairs[i].Value.Name + CsvSeparator);
                    }
                    else
                    {
                        sbColumns.Append(pairs[i].Value.Name).Append(CsvSeparator);
                    }
                }
            }

            private void MountCsvRows(ref StringBuilder sbRows, TEntity obj, params KeyValuePair<PropertyInfo, DataMemberAttribute>[] pairs)
            {
                for (int i = 0; i < pairs.Length; i++)
                {
                    string result = (null != obj.GetType().GetProperty(pairs[i].Key.Name).GetValue(obj, null)) ?
                            Convert.ChangeType(obj.GetType().GetProperty(pairs[i].Key.Name).GetValue(obj, null).ToString(), Type.GetTypeCode(pairs[i].Key.PropertyType)).ToString() : string.Empty;
                    result = result.Replace("\r", "").Replace("\n", "").Replace(CsvSeparator, " ");
                    if (i == pairs.Length - 1)
                    {

                        sbRows.AppendLine(result + CsvSeparator);
                    }
                    else
                    {
                        sbRows.Append(result).Append(CsvSeparator);
                    }
                }
            }
        }
    }
}
