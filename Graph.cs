using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Explanation of the Class
//I implemented 3 types of graphs:
//1. Adg.List:
//    Represented by a list of Nodes - an object that contains a data and a list of the nodes to
//    which it is linked
//2. Adg.List:
//    Represented by a dictionary whose key is the content of the element
//    And the value is the list of nodes to which it is linked
//3. Adg.Matrix:
//    Represented by a matrix

namespace DataAlgoritmim
{
    public class Node<T>
    {
        public T Data { get; set; }
        public LinkedList<Node<T>> Edges { get; set; }

        public Node(T data)
        {
            Data = data;
            Edges = new LinkedList<Node<T>>();
        }
    }

    // This class represents a directed graph, using adjacency list
    //implements with a LinkedList and object of type Node
    public class AdjacencyList<T>
    {
        LinkedList<Node<T>> adjList;
        int _n;


        public AdjacencyList()
        {
            adjList = new LinkedList<Node<T>>();
            _n = 0;
        }

        //Time complexity: O(1)
        public void addNode(T data)
        {
            _n++;
            adjList.AddLast(new Node<T>(data));
        }

        //Time complexity: O(V)
        public void addEdge(T u, T v)
        {
            foreach (Node<T> list in adjList)
            {
                if (list.Data.Equals(u))
                {
                    Node<T> _n = adjList.Where(x => x.Data.Equals(v)).FirstOrDefault();
                    if (_n != null)
                        list.Edges.AddLast(_n);
                    else
                        Console.WriteLine("Can't add a Node v");
                }
            }
        }

        //Time complexity: O(V)
        Dictionary<T, bool> ConvertListToDictionary()
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            foreach (Node<T> n in adjList)
            {
                visited.Add(n.Data, false);
            }
            return visited;
        }

        //Time complexity:O(V + E)
        public void BFS()
        {
            Dictionary<T, bool> visited = ConvertListToDictionary();

            foreach (Node<T> n in adjList)
            {
                if (!visited[n.Data])
                    BFSUtil(n, visited);
            }
            Console.WriteLine();
        }

        void BFSUtil(Node<T> n, Dictionary<T, bool> visited)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(n);

            while (queue.Count != 0)
            {
                n = queue.Dequeue();
                Console.Write(n.Data + " ");

                foreach (Node<T> i in n.Edges)
                {
                    if (!visited[i.Data])
                    {
                        queue.Enqueue(i);
                        visited[i.Data] = true;
                    }
                }
            }
        }

        //Time complexity:O(V + E)
        public void DFS()
        {
            Dictionary<T, bool> visited = ConvertListToDictionary();
            Stack<T> stack = new Stack<T>();

            foreach (Node<T> n in adjList)
            {
                if (!visited[n.Data])
                    DFSUtil(n, visited, stack);
            }
            Console.WriteLine();
        }

        void DFSUtil(Node<T> n, Dictionary<T, bool> visited, Stack<T> stack = null)
        {
            visited[n.Data] = true;

            foreach (Node<T> i in n.Edges)
            {
                if (!visited[i.Data])
                    DFSUtil(i, visited, stack);
            }
            if (stack != null)
                stack.Push(n.Data);
        }

        void printStack(Stack<T> stack)
        {
            foreach (T node in stack)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        //Time complexity:O(V + E)
        public void TopologicalSort()
        {
            DFS();
        }

        //Exercises 
        //GeeksforGeeks

        //1.
        //Given n nodes of a forest (collection of trees), find the number of trees in the forest.
        public int countTrees()
        {
            Dictionary<T, bool> visited = ConvertListToDictionary();
            int countTrees = 0;

            foreach (Node<T> n in adjList)
            {
                if (!visited[n.Data])
                {
                    DFSUtil(n, visited);
                    countTrees++;
                }
            }
            return countTrees;
        }


        //2.
        //Given two integers ‘n’ and ‘m’, find all the stepping numbers in range [n, m].
        //A number is called stepping number if all adjacent digits have an absolute difference of 1.
        //321 is a Stepping Number while 421 is not.
        public static void displaySteppingNumbers(int n, int m)
        {
            for (int i = 0; i <= 9; i++)
                displaySteppingNumbersUtil(n, m, i);
            Console.WriteLine();
        }

        static void displaySteppingNumbersUtil(int n, int m, int stepNum)
        {
            if (stepNum <= m && stepNum >= n)
                Console.Write(stepNum + " ");

            if (stepNum == 0 || stepNum > m)
                return;

            int lastDigit = stepNum % 10;

            int stepNumA = stepNum * 10 + (lastDigit - 1);
            int stepNumB = stepNum * 10 + (lastDigit + 1);

            if (lastDigit == 0)
                displaySteppingNumbersUtil(n, m, stepNumB);

            else if (lastDigit == 9)
                displaySteppingNumbersUtil(n, m, stepNumA);
            else
            {
                displaySteppingNumbersUtil(n, m, stepNumA);
                displaySteppingNumbersUtil(n, m, stepNumB);
            }
        }

        public static void IterativeDisplaySteppingNumbers(int n, int m)
        {
            int num, stepA, stepB;
            for (int i = n; i <= m; i++)
            {
                num = i;
                while (num > 0)
                {
                    stepA = num % 10;
                    stepB = num / 10 % 10;
                    num /= 10;
                    if (stepA == stepB + 1 || stepA == stepB - 1)
                        continue;
                    else
                        break;
                }
                if (num == 0)
                    Console.Write(i + " ");
            }
            Console.WriteLine();
        }

    }


    // This class represents a directed graph, using adjacency list
    //implements with a dictionary: key = data of a node
    //                              value = list of an edges
    public class AdjacencyListWithDictionary<T>
    {
        Dictionary<T, LinkedList<T>> adjList;

        public AdjacencyListWithDictionary()
        {
            adjList = new Dictionary<T, LinkedList<T>>();
        }

        //Time complexity: O(V)
        public void addNode(T data)
        {
            adjList.Add(data, new LinkedList<T>());
        }

        //Time complexity: O(1)
        public void addEdge(T u, T v)
        {
            adjList[u].AddLast(v);
        }

        //Time complexity: O(V)
        Dictionary<T, bool> ConvertListToDictionary()
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            foreach (T n in adjList.Keys)
            {
                visited.Add(n, false);
            }
            return visited;
        }

        //Time complexity:O(V + E)
        public void BFS()
        {
            Dictionary<T, bool> visited = ConvertListToDictionary();

            foreach (T n in adjList.Keys)
            {
                if (!visited[n])
                    BFSUtil(n, visited);
            }
            Console.WriteLine();
        }

        void BFSUtil(T n, Dictionary<T, bool> visited)
        {
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(n);

            while (queue.Count != 0)
            {
                n = queue.Dequeue();
                Console.Write(n + " ");

                foreach (T i in adjList[n])
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        //Time complexity:O(V + E)
        public void DFS()
        {
            Dictionary<T, bool> visited = ConvertListToDictionary();
            Stack<T> stack = new Stack<T>();
            foreach (T n in adjList.Keys)
            {
                if (!visited[n])
                    DFSUtil(n, visited,stack);
            }
            printStack(stack);
        }

        void DFSUtil(T n, Dictionary<T, bool> visited, Stack<T> stack = null)
        {
            visited[n] = true;

            foreach (T i in adjList[n])
            {
                if (!visited[i])
                    DFSUtil(i, visited, stack);
            }
            if (stack != null)
                stack.Push(n);
        }

        void printStack(Stack<T> stack)
        {
            foreach (T node in stack)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        //Time complexity:O(V + E)
        public void TopologicalSort()
        {
            DFS();
        }
    }

    // This class represents a directed graph
    // using adjacency Matrix
    public class AdjacencyMatrix
    {
        int[,] adjMatrix;
        int _n;

        //Time complexity: O(v^2)
        public AdjacencyMatrix(int n)
        {
            adjMatrix = new int[n, n];
            _n = n;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    adjMatrix[i, j] = 0;
        }

        //Time complexity: O(V^2)
        public void addNode(int x)
        {
            _n += x;
            int[,] adjMatrixTemp = new int[_n, _n];

            for (int i = 0; i < _n; i++)
                for (int j = 0; j < _n; j++)
                    adjMatrixTemp[i, j] = adjMatrix[i, j];
            adjMatrix = adjMatrixTemp;
        }

        //Time complexity: O(1)
        public void addEdge(int u, int v, int weight)
        {
            if (u >= _n || v >= _n)
                Console.WriteLine("Node does not exists!");
            if (u == v)
                Console.WriteLine("Same Node!");

            adjMatrix[u, v] = weight;
        }

        //BFS
        //Time complexity: O(v^2)
        public void BFS()
        {
            bool[] visited = new bool[_n];

            for (int i = 0; i < _n; i++)
            {
                if (visited[i] == false)
                    BFSUtil(i, visited);
            }
            Console.WriteLine();
        }

        void BFSUtil(int n, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            while (queue.Count != 0)
            {
                n = queue.Dequeue();
                Console.Write(n + " ");

                for (int i = 0; i < _n; i++)
                {
                    if (adjMatrix[n, i] != 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        //DFS
        //Time complexity: O(v^2)
        public void DFS()
        {
            bool[] visited = new bool[_n];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < _n; i++)
            {
                if (visited[i] == false)
                    DFSUtil(i, visited, stack);
            }
            printStack(stack);
        }

        void DFSUtil(int n, bool[] visited, Stack<int> stack = null)
        {
            visited[n] = true;

            for (int i = 0; i < _n; i++)
            {
                if (adjMatrix[n, i] != 0 && !visited[i])
                    DFSUtil(i, visited,stack);
            }
            if (stack != null)
                stack.Push(n);
        }

        void printStack(Stack<int> stack)
        {
            foreach (int node in stack)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }


        //Topological Sort
        //Time complexity: O(v^2)
        public void TopologicalSort()
        {
            DFS();
        }
    }
}
