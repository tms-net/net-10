namespace CsvSerializer.PropertyTree
{
    public interface INTreeNodeVisitor<TValue>
    {
        void Visit(NTreeNode<TValue> property);
    }

    public class NTreeNode<TValue>
    {
        public NTreeNode(TValue value = default) => Value= value;

        public TValue Value { get; set; }

        public List<NTreeNode<TValue>> Children { get; set; } = new();

    }

    public class NTree<TValue>
    {
        NTreeNode<TValue> _root;

        public NTree(NTreeNode<TValue> root)
        {
            _root = root;
        }

        /// <summary>
        /// Depth First Search Algorithm
        /// </summary>
        /// <param name="visitor"></param>
        public void TraversePropertyTreeDFS(INTreeNodeVisitor<TValue> visitor)
        {
            TraversePropertyTreeRecursive(_root, visitor);
        }

        /// <summary>
        /// Breadth First Search Algorithm
        /// </summary>
        /// <param name="visitor"></param>
        public void TraversePropertyTreeBFS(INTreeNodeVisitor<TValue> visitor)
        {
            var queue = new Queue<NTreeNode<TValue>>();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visitor.Visit(node);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        private void TraversePropertyTreeRecursive(NTreeNode<TValue> node, INTreeNodeVisitor<TValue> visitor)
        {
            visitor.Visit(node);

            foreach (var child in node.Children)
            {
                TraversePropertyTreeRecursive(child, visitor);
            }
        }
    }
}
