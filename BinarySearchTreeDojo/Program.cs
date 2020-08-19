using System;
using System.Collections.Generic;

namespace BinarySearchTreeDojo
{
    public class Program
    {
        public List<int> GenerateNumbers(int numOfItems)
        {
            var result = new List<int>();

            for (int i = 0; i < numOfItems; ++i)
            {
                result.Add(i * 2 + 5);
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Run the tests!");
            Program program = new Program();
            var listToAdd = program.GenerateNumbers(5);

            foreach(var item in listToAdd)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            var tree = BinarySearchTree.Build(listToAdd);
            Console.WriteLine("Tree Pre Order");
            tree.PreOrderTraversal();
            Console.ReadKey();
        }
    }
}
