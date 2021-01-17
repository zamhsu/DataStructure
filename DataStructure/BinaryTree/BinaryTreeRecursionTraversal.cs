using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeRecursionTraversal
    {
        /// <summary>
        /// 前序走訪(深度優先)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">樹</param>
        /// <returns></returns>
        public static List<T> PreOrder<T>(TreeNode<T> tree)
        {
            List<T> list = new List<T>(tree.Count);
            PreOrder(tree, list);
            return list;
        }

        private static void PreOrder<T>(TreeNode<T> tree, List<T> list)
        {
            list.Add(tree.Value);
            if (tree.Left != null)
                PreOrder(tree.Left, list);
            if (tree.Right != null)
                PreOrder(tree.Right, list);
        }

        /// <summary>
        /// 中序走訪(深度優先)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">樹</param>
        /// <returns></returns>
        public static List<T> InOrder<T>(TreeNode<T> tree)
        {
            List<T> list = new List<T>(tree.Count);
            InOrder(tree, list);
            return list;
        }

        private static void InOrder<T>(TreeNode<T> tree, List<T> list)
        {
            if (tree.Left != null)
                InOrder(tree.Left, list);
            list.Add(tree.Value);
            if (tree.Right != null)
                InOrder(tree.Right, list);
        }

        /// <summary>
        /// 後序走訪(深度優先)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">樹</param>
        /// <returns></returns>
        public static List<T> PostOrder<T>(TreeNode<T> tree)
        {
            List<T> list = new List<T>(tree.Count);
            PostOrder(tree, list);
            return list;
        }

        private static void PostOrder<T>(TreeNode<T> tree, List<T> list)
        {
            if (tree.Left != null)
                PostOrder(tree.Left, list);
            if (tree.Right != null)
                PostOrder(tree.Right, list);
            list.Add(tree.Value);
        }

        /// <summary>
        /// 廣度優先
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">樹</param>
        /// <returns></returns>
        public static List<T> BreadthFirst<T>(TreeNode<T> tree)
        {
            List<T> list = new List<T>(tree.Count);
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(tree);
            while (queue.Count > 0)
            {
                TreeNode<T> tempTree = queue.Dequeue();
                list.Add(tempTree.Value);
                if (tempTree.Left != null)
                    queue.Enqueue(tempTree.Left);
                if (tempTree.Right != null)
                    queue.Enqueue(tempTree.Right);
            }

            return list;
        }
    }
}
