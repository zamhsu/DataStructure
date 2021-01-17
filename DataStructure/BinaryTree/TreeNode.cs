using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public abstract class TreeNode<T>
    {
        public T Value;

        public abstract int Count { get; }
        public abstract int Depth { get; }
        public abstract TreeNode<T> Parent { get; }
        public abstract TreeNode<T> Left { get; }
        public abstract TreeNode<T> Right { get; }
        public abstract int Level { get; }

        public TreeNode(T value)
        {
            this.Value = value;
        }

        public abstract void AddLeft(T value);
        public abstract void AddRight(T value);
        public abstract void AddLeft(TreeNode<T> tree);
        public abstract void AddRight(TreeNode<T> tree);
        public abstract void Remove();
        public abstract TreeNode<T> Clone();

        public static void Copy(TreeNode<T> srcTree, TreeNode<T> destTree)
        {
            if (srcTree.Left != null)
            {
                destTree.AddLeft(srcTree.Left.Value);
                Copy(srcTree.Left, destTree.Left);
            }
            if (srcTree.Right != null)
            {
                destTree.AddRight(srcTree.Right.Value);
                Copy(srcTree.Right, destTree.Right);
            }
        }
    }
}
