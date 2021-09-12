using System;
using System.Collections;

namespace DataAlgoritmim
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////Hash Table

            ////top3Repeated
            //int[] arr1 = { 1, 5, 3, 2, 7, 1, 5, 3, 1, 5, 3 };
            //Hash.top3Repeated(arr1);

            ////areEqual
            //int[] arr2 = { 1, 2, 5, 4, 0 };
            //int[] arr3 = { 2, 4, 5, 0, 1 };
            //Console.WriteLine(Hash.areEqual(arr2, arr3));

            ////sum
            //int[] arr4 = new int[] { 1, 2, 3, 1, 3 };
            //Console.WriteLine(Hash.sum(arr4, arr4.Length));

            ////countPairs
            //int[] arr5 = { 1, 1, 2 };
            //Console.WriteLine(Hash.countPairs(arr5));


            //////////////Graph

            //// Creating a graph with 5 vertices 
            //AdjacencyList<int> adjList = new AdjacencyList<int>();

            //// Adding vertices one by one 
            //adjList.addNode(0);
            //adjList.addNode(1);
            //adjList.addNode(2);
            //adjList.addNode(3);
            //adjList.addNode(4);

            //// Adding edges one by one 
            //adjList.addEdge(0, 1);
            //adjList.addEdge(0, 4);
            //adjList.addEdge(1, 2);
            //adjList.addEdge(1, 3);
            //adjList.addEdge(1, 4);
            //adjList.addEdge(2, 3);
            //adjList.addEdge(3, 4);
            //adjList.addEdge(5, 4);

            //Console.WriteLine("BFS");
            //adjList.BFS();

            //Console.WriteLine("DFS");
            //adjList.DFS();

            //Console.WriteLine("Topogical Sort");
            //adjList.TopologicalSort();

            ////displaySteppingNumbers
            //int n = 0, m = 50;
            //Console.WriteLine("Stepping Numbers");
            //AdjacencyList<int>.displaySteppingNumbers(n, m);

            //Console.WriteLine("Stepping Numbers 2");
            //AdjacencyList<int>.IterativeDisplaySteppingNumbers(n, m);

            ////countTrees
            //Console.WriteLine("count Trees");
            //Console.WriteLine(adjList.countTrees());

            //////////////Binary_Tree

            ////NthInorder
            //Node root1 = new Node(10);
            //root1.Left = new Node(20);
            //root1.Right = new Node(30);
            //root1.Left.Left = new Node(40);
            //root1.Left.Right = new Node(50);

            //Console.WriteLine("NthInorder");
            //BinaryTree.NthInorder(root1, 4);
            //Console.WriteLine();

            ////checkLevelLeafNode
            //Node root2 = new Node(1);
            //root2.Left = new Node(2);
            //root2.Right = new Node(3);
            //root2.Left.Right = new Node(4);
            //root2.Right.Left = new Node(5);
            //root2.Right.Right = new Node(6);

            //Console.WriteLine("checkLevelLeafNode");
            //Console.WriteLine(BinaryTree.checkLevelLeafNode(root2));


            ////////////Sorting

            //void printArr(int[] arr)
            //{
            //    foreach (int i in arr)
            //    {
            //        Console.Write(i + " ");
            //    }
            //    Console.WriteLine();
            //}

            ////bubble sort
            //int[] _arr1 = new int[] { 3, 2, 4, 1, 7 };
            //Sorting.BubbleSort(_arr1);
            //printArr(_arr1);

            ////merge sort
            //int[] _arr2 = new int[] { 3, 2, 4, 1, 7 };
            //Sorting.MergeSort(_arr2);
            //printArr(_arr2);

            ////binary search
            //int[] _arr3 = new int[] { 1, 3, 4, 5, 7, 10 };
            //Sorting.BSA(_arr3, 4);
            //printArr(_arr3);

            ////Quick Sort
            //int[] _arr4 = new int[] { 1, 3, 4, 5, 7, 10 };
            //Sorting.QuickSort(_arr4);
            //printArr(_arr4);




            /////////////////////////////////////////////////////////Dijkstra


            AdjencyListWithWeight<string>  maps = new AdjencyListWithWeight<string>();

            maps.addNode("Nehariya");
            maps.addNode("Kiryat Shemona");
            maps.addNode("Haifa");
            maps.addNode("Tiberias");
            maps.addNode("Netanya");
            maps.addNode("Nazareth");
            maps.addNode("Tel Aviv");
            maps.addNode("Rishon");
            maps.addNode("Jerusalem");
            maps.addNode("Bet Shemesh");
            maps.addNode("Ashkelon");
            maps.addNode("Beer Sheva");
            maps.addNode("Dimona");
            maps.addNode("Mitzpe Ramon");
            maps.addNode("Eilat");

            maps.addEdge("Nehariya", "Haifa", 25);
            maps.addEdge("Nehariya", "Kiryat Shemona", 55);
            maps.addEdge("Nehariya", "Jerusalem", 135);

            maps.addEdge("Kiryat Shemona", "Tiberias", 45);

            maps.addEdge("Tiberias", "Haifa", 50);
            maps.addEdge("Tiberias", "Nazareth", 26);

            maps.addEdge("Haifa", "Nazareth", 35);
            maps.addEdge("Haifa", "Netanya", 52);

            maps.addEdge("Nazareth", "Netanya", 57);

            maps.addEdge("Netanya", "Tel Aviv", 31);

            maps.addEdge("Tel Aviv", "Rishon", 15);
            maps.addEdge("Tel Aviv", "Beer Sheva", 90);
            maps.addEdge("Tel Aviv", "Eilat", 280);

            maps.addEdge("Rishon", "Jerusalem", 34);
            maps.addEdge("Rishon", "Bet Shemesh", 30);
            maps.addEdge("Rishon", "Ashkelon", 40);

            maps.addEdge("Jerusalem", "Beer Sheva", 65);
            maps.addEdge("Jerusalem", "Dimona", 75);

            maps.addEdge("Bet Shemesh", "Beer Sheva", 55);

            maps.addEdge("Ashkelon", "Beer Sheva", 48);

            maps.addEdge("Beer Sheva", "Dimona", 30);
            maps.addEdge("Beer Sheva", "Mitzpe Ramon", 68);

            maps.addEdge("Mitzpe Ramon", "Eilat", 120);

            maps.distanceFromUtoV("Mitzpe Ramon", "Eilat");

            maps.distanceFromUtoV("Nehariya", "Tiberias");

            maps.distanceFromUtoV("Tel Aviv", "Eilat");

        }
    }
}
