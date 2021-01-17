using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryTree
{
    public class LinkedListBinaryTree<T> : TreeNode<T>
    {
        private int count;
        public override int Count 
        { 
            get
            {
                return count;
            }
        }

        private int depth;
        public override int Depth
        {
            get
            {
                return depth;
            }
        }

        private LinkedListBinaryTree<T> parent;
        public override TreeNode<T> Parent
        {
            get
            {
                return parent;
            }
        }

        private LinkedListBinaryTree<T> left;
        public override TreeNode<T> Left
        {
            get
            {
                return left;
            }
        }

        private LinkedListBinaryTree<T> right;
        public override TreeNode<T> Right
        {
            get
            {
                return right;
            }
        }

        private int level;
        public override int Level
        {
            get
            {
                return level;
            }
        }

        public LinkedListBinaryTree(T value) : base(value)
        {
            count = 1;
            depth = 1;
            level = 1;
        }

        public override void AddLeft(T value)
        {
            Add(ref left, value);
        }

        public override void AddRight(T value)
        {
            Add(ref right, value);
        }

        public override void AddLeft(TreeNode<T> tree)
        {
            Add(ref left, tree);
        }

        public override void AddRight(TreeNode<T> tree)
        {
            Add(ref right, tree);
        }

        protected void Add(ref LinkedListBinaryTree<T> child, T value)
        {
            Add(ref child, new LinkedListBinaryTree<T>(value));
        }

        protected void Add(ref LinkedListBinaryTree<T> child, TreeNode<T> treeNode)
        {
            if (child != null)
                throw new Exception("Child is existed");

            LinkedListBinaryTree<T> tempTree = treeNode as LinkedListBinaryTree<T>;
            if (tempTree == null)
            {
                tempTree = new LinkedListBinaryTree<T>(treeNode.Value);
                TreeNode<T>.Copy(treeNode, tempTree);
            }

            child = tempTree;
            child.level = level + 1;
            child.parent = this;

            if (depth == 1)
            {
                depth = 1;
                BubbleDepth();
            }

            ++count;
            BubbleCount(1);
        }

        public override void Remove()
        {
            LinkedListBinaryTree<T> sibling;
            if (parent == null)
            {
                return;
            }
            else if (parent.left == this)
            {
                parent.left = null;
                sibling = parent.right;
            }
            else if (parent.right == this)
            {
                parent.right = null;
                sibling = parent.left;
            }
            else
            {
                return;
            }

            if (depth + 1 == parent.depth)
            {
                if (sibling == null || sibling.depth < depth)
                    parent.UpdateDepth();
            }

            parent.count -= count;
            parent.BubbleCount(-count);
            parent = null;
        }

        public override TreeNode<T> Clone()
        {
            LinkedListBinaryTree<T> cloneTree = new LinkedListBinaryTree<T>(this.Value);
            if (this.parent == null)
            {
                cloneTree.count = this.count;
                cloneTree.depth = this.depth;
                cloneTree.left = this.left;
                cloneTree.left = (LinkedListBinaryTree<T>)this.left.Clone();
                cloneTree.right = (LinkedListBinaryTree<T>)this.right.Clone();
                cloneTree.left.parent = cloneTree;
                cloneTree.right.parent = cloneTree;
            }
            else
            {
                TreeNode<T>.Copy(this, cloneTree);
            }

            return cloneTree;
        }

        protected void BubbleDepth()
        {
            if (parent == null)
                return;

            if (depth + 1 > parent.depth)
            {
                parent.depth = depth + 1;
                parent.BubbleDepth();
            }
        }

        protected void BubbleCount(int diff)
        {
            if (parent == null)
                return;

            parent.count += diff;
            parent.BubbleCount(diff);
        }

        protected void UpdateDepth()
        {
            int tempDepth = depth;
            depth = 1;

            if (left != null)
                depth = left.depth + 1;
            if (right != null && right.depth + 1 > depth)
                depth = right.depth + 1;

            if (tempDepth == depth || parent == null)
                return;
            if (tempDepth + 1 == parent.depth)
                parent.UpdateDepth();
        }
    }
}
