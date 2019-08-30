using System.Collections.Generic;

namespace KnuthWithBFS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int initialState = 4;
            const int targetState = 5;

            List<Node> roots = new List<Node>()
            {
                new Node
                {
                    Operation = Operation.SquareRoot,
                    Parent = null
                },
                new Node
                {
                    Operation = Operation.Factorial,
                    Parent = null
                },
                new Node
                {
                    Operation = Operation.Floor,
                    Parent = null
                }
            };

            BFS bfs = new BFS(initialState);

            Node node = bfs.Search(roots, targetState);
            List<Operation> operations = Helper.BuildOperationList(node);

            Helper.PrintOperations(operations);
        }
    }
}
