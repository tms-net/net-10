using System.Text;

namespace Patterns.Behavioral
{
    class Node
    {
        public string Id;
        public Node Left;
        public Node Right;
    }

    //         ()
    //         ||
    //   ()<--  ---> ()
    //    |           |
    //    -> ()   ()<-

    

    internal interface IVisitor
    {
        void Accept(Node node);
        void AcceptSpecificNode(SpecificNode node);
    }

    class StringVisitor : IVisitor
    {
        IQueryable _queryable;

        StringBuilder _sb = new StringBuilder();

        public void Accept(Node node)
        {
            _sb.AppendFormat("{0} | ", node.Id);
        }
    }

}
