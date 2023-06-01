using System.Reflection;

namespace CsvSerializer.PropertyTree
{
    public class PropertyTreeBuilder
    {
        public static NTree<ClassProperty> BuildPropertyTree(Type type)
        {
            var root = new NTreeNode<ClassProperty>();
            BuildPropertyTreeRecursive(root, type);
            return new NTree<ClassProperty>(root);
        }

        private static void BuildPropertyTreeRecursive(NTreeNode<ClassProperty> parent, Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var child = new NTreeNode<ClassProperty>(
                    new ClassProperty
                    {
                        Name = property.Name,
                        Type = property.PropertyType
                    });

                if (!IsSystemType(property.PropertyType))
                {
                    BuildPropertyTreeRecursive(child, property.PropertyType);
                }

                parent.Children.Add(child);
            }
        }

        private static bool IsSystemType(Type type)
        {
            return type.Namespace?.StartsWith("System") == true;
        }
    }
}
