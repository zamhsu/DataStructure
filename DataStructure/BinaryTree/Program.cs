using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            LinkedListBinaryTree<string> binaryTree = new LinkedListBinaryTree<string>("A");
            binaryTree.AddLeft("B");
            binaryTree.AddRight("C");
            binaryTree.Left.AddLeft("D");
            binaryTree.Left.AddRight("E");
            binaryTree.Right.AddLeft("F");
            binaryTree.Right.AddRight("G");

            List<string> preOrderList = BinaryTreeRecursionTraversal.PreOrder(binaryTree);
            List<string> inOrderList = BinaryTreeRecursionTraversal.InOrder(binaryTree);
            List<string> postOrderList = BinaryTreeRecursionTraversal.PostOrder(binaryTree);
            List<string> breadthFirstList = BinaryTreeRecursionTraversal.BreadthFirst(binaryTree);

            StringBuilder preOrder = new StringBuilder();
            StringBuilder inOrder = new StringBuilder();
            StringBuilder postOrder = new StringBuilder();
            StringBuilder breadthFirst = new StringBuilder();

            for (int i = 0; i < preOrderList.Count; i++)
            {
                preOrder.Append(preOrderList[i]);

                if (i != preOrderList.Count - 1)
                    preOrder.Append(", ");
            }

            for (int i = 0; i < inOrderList.Count; i++)
            {
                inOrder.Append(inOrderList[i]);

                if (i != inOrderList.Count - 1)
                    inOrder.Append(", ");
            }

            for (int i = 0; i < postOrderList.Count; i++)
            {
                postOrder.Append(postOrderList[i]);

                if (i != postOrderList.Count - 1)
                    postOrder.Append(", ");
            }

            for (int i = 0; i < breadthFirstList.Count; i++)
            {
                breadthFirst.Append(breadthFirstList[i]);

                if (i != breadthFirstList.Count - 1)
                    breadthFirst.Append(", ");
            }

            Console.WriteLine($"前序走訪：{preOrder}");
            Console.WriteLine($"中序走訪：{inOrder}");
            Console.WriteLine($"後序走訪：{postOrder}");
            Console.WriteLine($"廣度優先：{breadthFirst}");

            Console.ReadLine();
        }
    }
}
