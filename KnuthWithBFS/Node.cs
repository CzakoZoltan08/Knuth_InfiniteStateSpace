using System.Collections.Generic;

namespace KnuthWithBFS
{
    public class Node
    {
        public Operation Operation { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();

        public void AddChild(Node child)
        {
            Children.Add(child);
        }
    }
}
