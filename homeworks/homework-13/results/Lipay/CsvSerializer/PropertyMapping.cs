using System.Reflection;

namespace CsvSerializer
{
    internal class PropertyMapping
        {
            public PropertyInfo PropertyInfo { get; set; }
            public PropertyMapping ParentProperty { get; internal set; }
            public Action<object, object> SetProperty { get; internal set; }
        }
    
}