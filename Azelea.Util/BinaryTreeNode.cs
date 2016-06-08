using System;

namespace Azelea.Util
{
    /// <summary>
    /// 二叉树节点
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class BinaryTreeNode<T>
    {
        private BinaryTreeNode<T> _LeftChild;
        private BinaryTreeNode<T> _RightChild;

        /// <summary>
        /// 节点高度，即以该节点作为根节点的树的高度
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// 节点元素
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public BinaryTreeNode<T> Parent { get; set; }
        /// <summary>
        /// 左孩子
        /// </summary>
        public BinaryTreeNode<T> LeftChild
        {
            get { return _LeftChild; }
            set
            {
                _LeftChild = value;
                UpdateHeight();
            }
        }
        /// <summary>
        /// 右孩子
        /// </summary>
        public BinaryTreeNode<T> RightChild
        {
            get { return _RightChild; }
            set
            {
                _RightChild = value;
                UpdateHeight();
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BinaryTreeNode()
        {
            Height = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="element">节点元素</param>
        public BinaryTreeNode(T element) : this()
        {
            Data = element;
        }

        /// <summary>
        /// 高度更新
        /// </summary>
        private void UpdateHeight()
        {
            int lh = LeftChild == null ? -1 : LeftChild.Height;
            int rh = RightChild == null ? -1 : RightChild.Height;
            int height = Math.Max(lh, rh) + 1;
            // 当前节点高度不变，所有祖先高度无需继续更新
            if (height != Height)
            {
                Height = height;
                if (Parent != null)
                {
                    Parent.UpdateHeight();
                }
            }
        }
    }
}
