using System;
using Xunit;

namespace Struct.TreeBinaryImpl.Tests
{
    public class BinaryTreeTests
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
        private BinaryTree _tree;

        public BinaryTreeTests()
        {
            // (1) Input
            var root = new TreeNode(8);
            root.Left = new TreeNode(5);
            root.Right = new TreeNode(4);
            
            root.Left.Left = new TreeNode(9);
            root.Left.Right = new TreeNode(7);
            root.Left.Right.Left = new TreeNode(1);
            root.Left.Right.Right = new TreeNode(12);
            root.Left.Right.Right.Left = new TreeNode(2);
            
            root.Right.Right = new TreeNode(11);
            root.Right.Right.Left = new TreeNode(3);

            _tree = new BinaryTree(root);
        }

        [Fact]
        public void TestInOrderTraversal()
        {
            var expeted = "9 5 1 7 2 12 8 4 3 11";
            
            var result = _tree.PrintInOrderTraversal();
            
            Assert.Equal(expeted, result);
        }

        [Fact]
        public void TestPreOrderTraversal()
        {
            var expeted = "8 5 9 7 1 12 2 4 11 3";
            
            var result = _tree.PrintPreOrderTraversal();
            
            Assert.Equal(expeted, result);
        }

        [Fact]
        public void TestPostOrderTraversal()
        {
            var expeted = "9 1 2 12 7 5 3 11 4 8";
            
            var result = _tree.PrintPostOrderTraversal();
            
            Assert.Equal(expeted, result);
        }
    }
}