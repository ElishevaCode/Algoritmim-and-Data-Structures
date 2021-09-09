using System;
using System.Collections.Generic;
using System.Text;

namespace DataAlgoritmim
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int key)
        {
            Data = key;
            Left = Right = null;
        }
    }

    class BinaryTree
    {
        Node root;

        public BinaryTree(int key)
        {
            root = new Node(key);
        }


        //BFS
        //Time Complexity: o(n)
        public void BFS()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                Node tempNode = queue.Dequeue();
                Console.Write(tempNode.Data + " ");

                if (tempNode.Left != null)
                {
                    queue.Enqueue(tempNode.Left);
                }

                if (tempNode.Right != null)
                {
                    queue.Enqueue(tempNode.Right);
                }
            }
        }

        //DFS
        //Time Complexity: o(n)  
        void DFSUtil(Node tree)
        {
            if (tree != null)
            {
                Console.Write(tree.Data + " ");
                DFSUtil(tree.Left);
                DFSUtil(tree.Right);
            }
        }

        public void DFS()
        {
            DFSUtil(root);
        }

        public static int count = 0;

        //Given the binary tree and you have to find out the n-th node of inorder traversal.
        public static void NthInorder(Node node, int n)
        {
            if (node == null)
                return;

            if (count <= n)
            {
                NthInorder(node.Left, n);
                count++;
                if (n == count)
                    Console.WriteLine(node.Data);
                NthInorder(node.Right, n);
            }
        }

        //Given a Binary Tree, check if all leaves are at same level or not. 
        public static bool checkLevelLeafNode(Node root)
        {
            if (IsSameLevel(root) == -1)
                return false;
            return true;
        }

        public static int IsSameLevel(Node root)
        {
            if (root == null)
                return 0;
            int l = IsSameLevel(root.Left);
            int r = IsSameLevel(root.Right);
            if (root.Left != null && root.Right != null && (l == -1 || r == -1 || l != r ))
                return -1;
            if (root.Left == null)
                return r + 1;
            return l + 1;
        }

    }
}
