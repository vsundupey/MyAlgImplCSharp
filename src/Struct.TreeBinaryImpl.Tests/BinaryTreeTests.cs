using System;
using Xunit;

namespace Struct.TreeBinaryImpl.Tests
{
    public class BinaryTreeTests
    {
        private BinaryTree _tree;

        public BinaryTreeTests()
        {            
        }

        [Fact]
        public void TestInOrderTraversal()
        {
            var rootNode = TreeTestsHelper.CreateSimpleBT();
            _tree = new BinaryTree(rootNode);
            var expeted = "9 5 1 7 2 12 8 4 3 11";

            var result = _tree.PrintInOrderTraversal();

            Assert.Equal(expeted, result);
        }

        [Fact]
        public void TestPreOrderTraversal()
        {
            var rootNode = TreeTestsHelper.CreateSimpleBT();
            _tree = new BinaryTree(rootNode);
            var expeted = "8 5 9 7 1 12 2 4 11 3";

            var result = _tree.PrintPreOrderTraversal();

            Assert.Equal(expeted, result);
        }

        [Fact]
        public void TestPostOrderTraversal()
        {
            var rootNode = TreeTestsHelper.CreateSimpleBT();
            _tree = new BinaryTree(rootNode);
            var expeted = "9 1 2 12 7 5 3 11 4 8";

            var result = _tree.PrintPostOrderTraversal();

            Assert.Equal(expeted, result);
        }

        [Fact]
        public void InsertShouldBeOk()
        {
            _tree = new BinaryTree();
            
            _tree.Insert(5);
            _tree.Insert(3);
            _tree.Insert(4);
            _tree.Insert(6);
            
            Assert.True(_tree.Contains(4));
        }

        //TODO create tests for negative cases
        //[Fact]
        public void TestTreeforFull()
        {
            Assert.True(_tree.IsFull());
        }

        //[Fact]
        public void TestTreeForComplete()
        {
            Assert.True(_tree.IsComplete());
        }

        //[Fact]
        public void TestTreeForBalance()
        {
            Assert.True(_tree.IsBalanced());
        }
    }

    public static class TreeTestsHelper
    {
        /*
            (1) Input - tree for test traversal types
        
                                     (8)
                                   *     *
                                *           *
                             *                 *
                            (5)                (4)
                           *   *                   *
                         *       *                   *
                       (9)        (7)                 (11)
                                 *   *                *
                               *       *             *
                             (1)        (12)       (3)
                                                   *
                                                  *
                                                (2)
         */
        public static TreeNode CreateSimpleBT()
        {
            var tree = new TreeNode(8);
            tree.Left = new TreeNode(5);
            tree.Right = new TreeNode(4);

            tree.Left.Left = new TreeNode(9);
            tree.Left.Right = new TreeNode(7);
            tree.Left.Right.Left = new TreeNode(1);
            tree.Left.Right.Right = new TreeNode(12);
            tree.Left.Right.Right.Left = new TreeNode(2);

            tree.Right.Right = new TreeNode(11);
            tree.Right.Right.Left = new TreeNode(3);

            return tree;
        }
    }
}