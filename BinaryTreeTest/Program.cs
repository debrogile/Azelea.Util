using Azelea.Util;
using System;

namespace BinaryTreeTest
{
    class Program
    {
        private const int HEIGHT = 5;
        private const int MIN = 0;
        private const int MAX = HEIGHT * HEIGHT * HEIGHT;
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            ///Vector<T> a;

            // 随机生成高度为 HEIGHT 的二叉树
            var tree = new BinaryTree<int>();
            var root = tree.InsertAsRoot(rand.Next(MIN, MAX));
            CreateTree(tree, root, HEIGHT);

            Console.WriteLine("先序遍历：");
            tree.PreOrder(n =>
            {
                Console.Write(string.Format("{0} ", n));
            });
            Console.WriteLine();

            Console.WriteLine("中序遍历：");
            tree.InOrder(n =>
            {
                Console.Write(string.Format("{0} ", n));
            });
            Console.WriteLine();

            Console.WriteLine("后序遍历：");
            tree.PostOrder(n =>
            {
                Console.Write(string.Format("{0} ", n));
            });
            Console.WriteLine();

            Console.WriteLine("层次遍历：");
            tree.LevelOrder(n =>
            {
                Console.Write(string.Format("{0} ", n));
            });
            Console.WriteLine();
        }

        static void CreateTree(BinaryTree<int> tree, BinaryTreeNode<int> parent, int height)
        {
            if (height == 0)
            {
                return;
            }

            if (rand.Next(height) > 0)
            {
                CreateTree(tree, tree.InsertAsLeftChild(parent, rand.Next(MIN, MAX)), height - 1);
            }

            if (rand.Next(height) > 0)
            {
                CreateTree(tree, tree.InsertAsRightChild(parent, rand.Next(MIN, MAX)), height - 1);
            }
        }
    }
}
