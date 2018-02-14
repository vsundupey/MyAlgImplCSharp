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

        public void Insert(int value)
        {
            if (value <= Data)
            {
                if (Left == null)
                    Left = new TreeNode(value);
                else
                    Left.Insert(value);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode(value);
                else
                    Right.Insert(value);
            }
        }

        public bool Contains(int value)
        {
            if (Data == value)
                return true;

            
            if (value < Data)
            {
                if (Left == null)
                    return false;
                
                return Left.Contains(value);
            }
            else
            {
                if (Right == null)
                    return false;
                
                return Right.Contains(value);
            }
        }

        //TODO Remove
        public void Remove(int value)
        {
            throw new NotImplementedException();
        }
        
        #region For Todo
        
        // TODO IsBalanced()
        public bool IsBalanced()
        {
            throw new NotImplementedException();
        }

        // TODO need to understand BFS/BFT
        public bool IsComplete()
        {
            throw new NotImplementedException();
        }

        // TODO need to understand BFS/BFT
        public bool IsFull()
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class BinaryTree
    {
        private bool _enableDuplicates;
        private TreeNode _root;
        private int _count;

        private readonly StringBuilder _treeValuesAsString;

        public BinaryTree(bool enableDuplcates = false)
        {
            _enableDuplicates = enableDuplcates;
            _treeValuesAsString = new StringBuilder();
        }

        public BinaryTree(TreeNode root)
        {
            _treeValuesAsString = new StringBuilder();
            _root = root;
        }

        public void Insert(int data)
        {
            if (_root == null)
                _root = new TreeNode(data);
            else
                _root.Insert(data);
        }

        public bool Contains(int data)
        {
            if (_root == null)
                return false;

            return _root.Contains(data);
        }

        public void Remove(int data)
        {
            _root?.Remove(data);
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
        
        public bool IsBalanced()
        {
            return _root.IsBalanced();
        }

        public bool IsComplete()
        {
            return _root.IsComplete();
        }

        public bool IsFull()
        {
            return _root.IsFull();
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