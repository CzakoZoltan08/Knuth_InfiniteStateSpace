using System;
using System.Collections.Generic;
using System.Linq;

namespace KnuthWithBFS
{
    public static class Helper
    {
        public static bool IsTerminationCriteriaReached(double currentResult, double targetValue)
        {
            const double epsilon = 0.01;
            return Math.Abs(currentResult - targetValue) < epsilon;
        }

        public static List<Operation> BuildOperationList(Node currentNode)
        {
            List<Operation> operations = new List<Operation>();
            while (currentNode != null)
            {
                operations.Add(currentNode.Operation);
                currentNode = currentNode.Parent;
            }

            operations.Reverse();

            return operations;
        }

        public static double ApplyOperations(ulong number, IEnumerable<Operation> operations)
        {
            // Very unlikely situation, we skip this because we don't have memory for that big number
            if(operations.Count(op => op == Operation.Factorial) >= 3)
            {
                return 0;
            }

            double result = number;
            foreach(Operation operation in operations)
            {
                result = ApplyOperation(result, operation);
            }

            return result;
        }

        public static void PrintOperations(List<Operation> operations)
        {
            foreach(Operation operation in operations)
            {
                Console.WriteLine(operation);
            }
        }

        private static double ApplyOperation(double number, Operation operation)
        {
            switch (operation)
            {
                case Operation.Factorial:
                    return Factorial(number);
                case Operation.Floor:
                    return Math.Floor(number);
                case Operation.SquareRoot:
                    return Math.Sqrt(number);
                default:
                    return 0;
            }
        }

        private static double Factorial(double number)
        {
            double result = 1;
            for(ulong i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
