using System.Collections.Generic;

namespace KnuthWithBFS
{
    public class BFS
    {
        private ulong _initialState;

        public BFS(ulong initialState)
        {
            this._initialState = initialState;
        }

        public Node Search(List<Node> roots, ulong targetState)
        {
            Queue<Node> Q = new Queue<Node>();
            HashSet<Node> S = new HashSet<Node>();

            if (this._initialState == targetState)
            {
                return new Node();
            }

            foreach(Node root in roots)
            {
                EnqueuAll(Q, root);
                S.Add(root);
            }

            while (true)
            {
                Node currentNode = Q.Dequeue();

                List<Operation> operations = Helper.BuildOperationList(currentNode);
                double currentResult = Helper.ApplyOperations(this._initialState, operations);

                if (Helper.IsTerminationCriteriaReached(currentResult, targetState))
                {
                    return currentNode;
                }

                foreach (Node node in currentNode.Children)
                {
                    if (!S.Contains(node))
                    {
                        EnqueuAll(Q, node);
                        S.Add(node);
                    }
                }
            }
        }

        private List<Node> SetupChildren(Node node)
        {
            List<Node> children = new List<Node>()
            {
                new Node
                {
                    Operation = Operation.SquareRoot,
                    Parent = node
                },
                new Node
                {
                    Operation = Operation.Factorial,
                    Parent = node
                },
                new Node
                {
                    Operation = Operation.Floor,
                    Parent = node
                }
            };

            node.Children = children;

            return children;
        }

        private void EnqueuAll(Queue<Node> queue, Node node)
        {
            List<Node> currentChildren = SetupChildren(node);

            queue.Enqueue(node);
            foreach (Node child in currentChildren)
            {
                queue.Enqueue(child);
            }
        }
    }
}
