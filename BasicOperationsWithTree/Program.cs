using System;
using BinaryTrees.Model;

namespace BasicOperationsWithTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = GetBalancedBinaryTree();

            Console.WriteLine("tree implemented successfully..");
            Console.WriteLine($"Is value of 1 present in tree: {tree.Find(1)}");

            tree.PreOrderTraversal(tree.Root);
            Console.WriteLine();
            tree.InOrderTraversal(tree.Root);
            Console.WriteLine();
            Console.WriteLine($"height of the tree is {tree.GetHeight(tree.Root)}");
            Console.WriteLine();
            Console.WriteLine($"minimum value in a tree is {tree.GetMinimumValue(GetBinaryTree())}");
            Console.WriteLine();
            Console.WriteLine($"Binary search tree validation: {tree.IsValidBinarySearchTree(GetBinaryTree())}");
            Console.WriteLine($"Binary search tree validation: {tree.IsValidBinarySearchTree(GetBalancedBinaryTree().Root)}");
            Console.WriteLine();
            Console.Write($"Nodes @Kth distance (2):");
            tree.PrintNodesAtKthDistance(GetBalancedBinaryTree().Root, 2);
        }

        private static BinaryTree.Node GetBinaryTree()
        {
            var node = new BinaryTree.Node(20)
            {
                LeftChild = new BinaryTree.Node(10),
                RightChild = new BinaryTree.Node(30)
                {
                    LeftChild = new BinaryTree.Node(4),
                    RightChild = new BinaryTree.Node(31) {RightChild = new BinaryTree.Node(-12)}
                }
            };
            
            node.LeftChild.RightChild = new BinaryTree.Node(21);
            node.LeftChild.LeftChild = new BinaryTree.Node(6)
            {
                LeftChild = new BinaryTree.Node(3), RightChild = new BinaryTree.Node(8)
            };

            return node;
        }

        private static BinaryTree GetBalancedBinaryTree()
        {
            var tree = new BinaryTree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);
            return tree;
        }
    }
}