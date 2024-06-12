namespace CsvSerializer.PropertyTree
{
    public class DeserializationVisitor : INTreeNodeVisitor<ClassProperty>
    {
        private string[] _values;
        private object _instance;

        public DeserializationVisitor(object instance, string[] values)
        {
            _instance = instance;
            _values = values;
        }

        public void Visit(NTreeNode<ClassProperty> property)
        {
        }
    }
}
