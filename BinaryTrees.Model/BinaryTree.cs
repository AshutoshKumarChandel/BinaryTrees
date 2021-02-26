using System;

#pragma warning disable 169
namespace BinaryTrees.Model
{
    public class BinaryTree
    {
        public class Node
        {
            private readonly int _value;

            public Node LeftChild;

            public Node RightChild;

            public Node(int value)
            {
                _value = value;
            }

            public int GetValue()
            {
                return _value;
            }

            public override string ToString()
            {
                return $"Node: {this._value}";
            }
        }

        public Node Root;

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);

                return;
            }

            var current = Root;
            while (true)
            {
                if (value < current.GetValue())
                {
                    if (IsNull(current.LeftChild))
                    {
                        current.LeftChild = new Node(value);
                        
                        break;
                    }
                    
                    current = current.LeftChild;
                }
                else
                {
                    if (IsNull(current.RightChild))
                    {
                        current.RightChild = new Node(value);
                        
                        break;
                    }

                    current = current.RightChild;
                }
            }
        }

        public bool Find(int value)
        {
            return IsValuePresent(Root, value);
        }

        public void PreOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write($"{node.GetValue()} -> ");
            PreOrderTraversal(node.LeftChild);
            PreOrderTraversal(node.RightChild);
        }

        public void InOrderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.LeftChild);
            Console.Write($"{node.GetValue()} -> ");
            InOrderTraversal(node.RightChild);
        }

        private bool IsValuePresent(Node node, int value)
        {
            if (IsNull(node))
            {
                return false;
            }

            return value == node.GetValue() || (value < node.GetValue()
                ? IsValuePresent(node.LeftChild, value)
                : IsValuePresent(node.RightChild, value));
        }

        private bool IsNull(Node node)
        {
            return node == null;
        }

        public int GetHeight(Node node)
        {
            if (IsLeafNode(node))
            {
                return 0;
            }
            
            return 1 + Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));
        }

        private bool IsLeafNode(Node node)
        {
            return IsNull(node.LeftChild) && IsNull(node.RightChild);
        }

        public int GetMinimumValue(Node node)
        {
            if (IsNull(node.LeftChild) && !IsNull(node.RightChild))
            {
                return GetMinimumValue(node.RightChild);
            }

            if (!IsNull(node.LeftChild) && IsNull(node.RightChild))
            {
                return GetMinimumValue(node.LeftChild);
            }
            
            if(IsLeafNode(node))
            {
                return node.GetValue();
            }

            var leftMin = GetMinimumValue(node.LeftChild);
            var rightMin = GetMinimumValue(node.RightChild);
            
            return Math.Min(Math.Min(leftMin, rightMin), node.GetValue());
        }

        public bool IsValidBinarySearchTree(Node node)
        {
            if (IsNull(node))
            {
                return true;
            }
            
            return Validate(node, Int32.MinValue, Int32.MaxValue);
        }

        private bool Validate(Node node, int minValue, int maxValue)
        {
            if (IsNull(node))
            {
                return true;
            }

            if (node.GetValue() > maxValue || node.GetValue() < minValue)
            {
                return false;
            }

            return Validate(node.LeftChild, minValue, node.GetValue() - 1)
                   && Validate(node.RightChild, node.GetValue() + 1, maxValue);
        }

        public void PrintNodesAtKthDistance(Node node, int distance)
        {
            if (IsNull(node))
            {
                return;
            }

            if (distance == 0)
            {
                Console.Write($"{node.GetValue()} -> ");
                return;
            }

            PrintNodesAtKthDistance(node.LeftChild, distance - 1);
            PrintNodesAtKthDistance(node.RightChild, distance - 1);
        }
    }
}