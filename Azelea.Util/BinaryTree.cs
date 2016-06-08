using System;
using System.Collections.Generic;

namespace Azelea.Util
{
    /// <summary>
    /// 二叉树
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class BinaryTree<T>
    {
        /// <summary>
        /// 规模
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 根节点
        /// </summary>
        public BinaryTreeNode<T> Root { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BinaryTree()
        {
            Count = 0;
            Root = null;
        }

        /// <summary>
        /// 插入根节点
        /// </summary>
        /// <param name="element">待插入节点元素</param>
        /// <returns>返回插入的节点</returns>
        public BinaryTreeNode<T> InsertAsRoot(T element)
        {
            Count = 1;
            Root = new BinaryTreeNode<T>
            {
                Data = element
            };

            return Root;
        }

        /// <summary>
        /// 插入左孩子
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <param name="element">待插入节点元素</param>
        /// <returns>返回插入的节点</returns>
        public BinaryTreeNode<T> InsertAsLeftChild(BinaryTreeNode<T> parent, T element)
        {
            if (parent.LeftChild == null)
            {
                Count++;
                var node = new BinaryTreeNode<T>(element)
                {
                    Parent = parent
                };

                return parent.LeftChild = node;
            }
            else
            {
                throw new Exception("插入节点失败，目标父节点左孩子不为空。");
            }
        }

        /// <summary>
        /// 插入右孩子
        /// </summary>
        /// <param name="parent">父节点</param>
        /// <param name="element">待插入节点元素</param>
        /// <returns>返回插入的节点</returns>
        public BinaryTreeNode<T> InsertAsRightChild(BinaryTreeNode<T> parent, T element)
        {
            if (parent.RightChild == null)
            {
                Count++;
                var node = new BinaryTreeNode<T>(element)
                {
                    Parent = parent
                };

                return parent.RightChild = node;
            }
            else
            {
                throw new Exception("插入节点失败，目标父节点右孩子不为空。");
            }
        }

        /// <summary>
        /// 先序遍历
        /// </summary>
        /// <param name="visit">元素访问方法</param>
        public void PreOrder(Action<T> visit)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;
            while (true)
            {
                VisitAlongLeftBranch(node, stack, visit);
                if (stack.Count == 0)
                {
                    break;
                }
                else
                {
                    node = stack.Pop();
                }
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="visit">元素访问方法</param>
        public void InOrder(Action<T> visit)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var node = Root;
            while (true)
            {
                GoAlongLeftBranch(node, stack);
                if (stack.Count == 0)
                {
                    break;
                }
                else
                {
                    node = stack.Pop();
                    visit(node.Data);
                    node = node.RightChild;
                }
            }
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="visit">元素访问方法</param>
        public void PostOrder(Action<T> visit)
        {
            BinaryTreeNode<T> preVisitNode = null;
            var stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (node != null)
                {
                    if ((node.LeftChild == null && node.RightChild == null) ||
                        (preVisitNode != null && preVisitNode.Parent == node))
                    {
                        visit(node.Data);
                        preVisitNode = node;
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(node.RightChild);
                        stack.Push(node.LeftChild);
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        /// <summary>
        /// 层次遍历
        /// </summary>
        /// <param name="visit">元素访问方法</param>
        public void LevelOrder(Action<T> visit)
        {
            var queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node != null)
                {
                    visit(node.Data);
                    queue.Enqueue(node.LeftChild);
                    queue.Enqueue(node.RightChild);
                }
            }
        }

        private void VisitAlongLeftBranch(BinaryTreeNode<T> node, Stack<BinaryTreeNode<T>> stack, Action<T> visit)
        {
            while (node != null)
            {
                visit(node.Data);
                stack.Push(node.RightChild);
                node = node.LeftChild;
            }
        }

        private void GoAlongLeftBranch(BinaryTreeNode<T> node, Stack<BinaryTreeNode<T>> stack)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.LeftChild;
            }
        }
    }
}
