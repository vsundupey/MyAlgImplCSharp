using System;
using System.Dynamic;
using System.Text;

namespace Struct.TreeBinaryImpl
{
    public class TreeNode
    {
        public readonly int Data;
        
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int data)
        {
            Data = data;
        }
    }

    public class BinaryTree
    {
        private readonly TreeNode _root;
        private int _count;

        private readonly StringBuilder _treeValuesAsString;

        public BinaryTree()
        {
            _treeValuesAsString = new StringBuilder();
        }

        public BinaryTree(TreeNode root) : base()
        {
            _treeValuesAsString = new StringBuilder();
            _root = root;
        }

        private string PrintTraversal(Action haunlder)
        {
            _count = 0;
            _treeValuesAsString.Clear();
            haunlder.Invoke();
            Console.WriteLine(_treeValuesAsString);
            return _treeValuesAsString.ToString().TrimEnd();
        }

        public string PrintInOrderTraversal()
        {
            return PrintTraversal(() => InOrderTraversal(_root));
        }

        public string PrintPreOrderTraversal()
        {
            return PrintTraversal(() => PreOrderTraversal(_root));
        }

        public string PrintPostOrderTraversal()
        {
            return PrintTraversal(() => PostOrderTraversal(_root));
        }

        private void InOrderTraversal(TreeNode node)
        {
            if (node.Left != null)
                InOrderTraversal(node.Left);

            _treeValuesAsString.Append($"{node.Data} ");

            if (node.Right != null)
                InOrderTraversal(node.Right);
            
            _count++;
        }

        private void PreOrderTraversal(TreeNode node)
        {
            _treeValuesAsString.Append($"{node.Data} ");
            
            if (node.Left != null)
                PreOrderTraversal(node.Left);
            if (node.Right != null)
                PreOrderTraversal(node.Right);
            
            _count++;
        }

        private void PostOrderTraversal(TreeNode node)
        {
            if (node.Left != null)
                PostOrderTraversal(node.Left);
            if (node.Right != null)
                PostOrderTraversal(node.Right);
            
            _treeValuesAsString.Append($"{node.Data} ");
            _count++;
        }
        
        public bool Contains(int data)
        {
            return false;
        }

        public bool IsBalanced()
        {
            throw new NotImplementedException();
        }

        public bool IsComplete()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        public void PrintInfo()
        {
            Console.WriteLine("Binary tree");
            Console.WriteLine($"Tree size: {_count}");
            Console.WriteLine($"Complete: {IsComplete()}");
            Console.WriteLine($"Balanced: {IsBalanced()}");
            Console.WriteLine($"Full    : {IsFull()}");
        }
    }
}