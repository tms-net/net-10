using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace CsvSerializer
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

    public sealed class CsvSerializer : CsvSerializerAbstraction<DataRow>
    {
        private CsvSerializer(CsvSerializerSettings csvSerializerSettings) : base(csvSerializerSettings)
        {
        }
    }

    public sealed class CsvSerializer<TEntity> : CsvSerializerAbstraction<TEntity>
        where TEntity : class
    {
        private CsvSerializer(CsvSerializerSettings csvSerializerSettings) : base(csvSerializerSettings)
        {
        }

        public static string Serialize(CsvSerializerSettings csvSerializerSettings, List<TEntity> collection)
        {
            return Serialize(csvSerializerSettings, collection.ToArray());
        }

        public static string Serialize(CsvSerializerSettings csvSerializerSettings, params TEntity[] collection)
        {
            return (new CsvSerializer<TEntity>(csvSerializerSettings)).CustomSerialize(collection);
        }

        protected string CustomSerialize(params TEntity[] collection)
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

        public static IEnumerable<TEntity> Deserialize(CsvSerializerSettings csvSerializerSettings, string csvString)
        {
            return (new CsvSerializer<TEntity>(csvSerializerSettings)).CustomDeserialize(csvString);
        }

        protected IEnumerable<TEntity> CustomDeserialize(string csvString)
        {
            string[] arrayLinesCsv = csvString.Split('\n');
            string[] columnsName = arrayLinesCsv[0].Split(base._csvSeparator);
            Type tp = typeof(TEntity);
            PropertyInfo[] props = tp.GetProperties();
            for (int i = 1; i < arrayLinesCsv.Length - 1; i++)
            {
                object instance = Activator.CreateInstance(tp);
                string[] columnsValue = arrayLinesCsv[i].Split(base._csvSeparator);
                for (int j = 0; j < columnsValue.Length - 1; j++)
                {
                    PropertyInfo prop = null;
                    for (int x = 0; x < props.Length; x++)
                    {
                        DataMemberAttribute att = props[x].GetCustomAttribute(typeof(DataMemberAttribute)) as DataMemberAttribute;
                        if ((null != att && att.Name == columnsName[j]) || columnsName[j] == props[x].Name)
                        {
                            prop = props[x];
                        }
                        if (null != prop)
                        {
                            prop.SetValue(instance, Convert.ChangeType(columnsValue[j], Type.GetTypeCode(prop.PropertyType)), null);
                        }
                    }
                }
                yield return (instance as TEntity);
            }
        }
    }
}