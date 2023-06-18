using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsvSerializer
{
    internal class PropertyMapping
    {
        public PropertyInfo PropertyInfo { get; set; }
        public PropertyMapping ParentProperty { get; internal set; }
        public Action<object, object> SetProperty { get; internal set; }
    }
}
