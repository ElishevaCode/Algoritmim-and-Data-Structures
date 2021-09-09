using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        int _v;


        public AdjacencyList()
        {
            adjList = new LinkedList<Node<T>>();
            _v = 0;
        }

        // A function to add a Node
        //Time complexity: O(1)
        public void addNode(T data)
        {
            _v++;
            adjList.AddLast(new Node<T>(data));
        }

        // A function to add an edge
        //Time complexity: O(V)
        public void addEdge(T u, T v)
        {
            foreach (Node<T> list in adjList)
            {
                if (list.Data.Equals(u))
                {
                    Node<T> _v = adjList.Where(x => x.Data.Equals(v)).FirstOrDefault();
                    if (_v != null)
                        list.Edges.AddLast(_v);
                    else
                        Console.WriteLine("Can't add a Node v");
                }
            }
        }

        //Auxiliary function that creates a dictionary from the elements of the graph
        //For each element it inserts an initial value - false
        //Time complexity: O(V)
        Dictionary<T, bool> listToDictionary()
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            foreach (Node<T> v in adjList)
            {
                visited.Add(v.Data, false);
            }
            return visited;
        }

        //BFS
        //Time complexity:O(V + E)
        public void BFS()
        {
            Dictionary<T, bool> visited = listToDictionary();

            foreach (Node<T> v in adjList)
            {
                if (!visited[v.Data])
                    BFSUtil(v, visited);

            }
            Console.WriteLine();
        }

        void BFSUtil(Node<T> v, Dictionary<T, bool> visited)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(v);

            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                Console.Write(v.Data + " ");

                foreach (Node<T> i in v.Edges)
                {
                    if (!visited[i.Data])
                    {
                        queue.Enqueue(i);
                        visited[i.Data] = true;
                    }
                }
            }
        }

        //DFS
        //Time complexity:O(V + E)
        public void DFS()
        {
            Dictionary<T, bool> visited = listToDictionary();

            foreach (Node<T> v in adjList)
            {
                if (!visited[v.Data])
                    DFSUtil(v, visited);
            }
            Console.WriteLine();
        }

        void DFSUtil(Node<T> v, Dictionary<T, bool> visited)
        {
            visited[v.Data] = true;
            Console.Write(v.Data + " ");

            foreach (Node<T> i in v.Edges)
            {
                if (!visited[i.Data])
                    DFSUtil(i, visited);
            }
        }

        //Topological Sort
        //Time complexity:O(V + E)
        public void TopologicalSort()
        {
            Stack<T> stack = new Stack<T>();
            Dictionary<T, bool> visited = listToDictionary();

            foreach (Node<T> v in adjList)
            {
                if (!visited[v.Data])
                    TopologicalSortUtil(v, visited, stack);
            }

            foreach (T node in stack)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        void TopologicalSortUtil(Node<T> v, Dictionary<T, bool> visited, Stack<T> stack)
        {
            visited[v.Data] = true;

            foreach (Node<T> node in v.Edges)
            {
                if (!visited[node.Data])
                    TopologicalSortUtil(node, visited, stack);
            }
            stack.Push(v.Data);
        }

        //Exercises 
        //GeeksforGeeks

        //1.
        //Given n nodes of a forest (collection of trees), find the number of trees in the forest.
        public int countTrees()
        {
            Dictionary<T, bool> visited = listToDictionary();
            int countTrees = 0;

            foreach (Node<T> v in adjList)
            {
                if (!visited[v.Data])
                {
                    DFSUtil(v, visited);
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

        //Iterative implements to displaySteppingNumbers
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

        // A function to add a Node
        //Time complexity: O(V)
        public void addNode(T data)
        {
            adjList.Add(data, new LinkedList<T>());
        }

        // A function to add an edge
        //Time complexity: O(1)
        public void addEdge(T u, T v)
        {
            adjList[u].AddLast(v);
        }

        //Auxiliary function that creates a dictionary from the elements of the graph
        //For each element it inserts an initial value - false
        //Time complexity: O(V)
        Dictionary<T, bool> listToDictionary()
        {
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            foreach (T v in adjList.Keys)
            {
                visited.Add(v, false);
            }
            return visited;
        }

        //BFS
        //Time complexity:O(V + E)
        public void BFS()
        {
            Dictionary<T, bool> visited = listToDictionary();

            foreach (T v in adjList.Keys)
            {
                if (!visited[v])
                    BFSUtil(v, visited);
            }
            Console.WriteLine();
        }

        void BFSUtil(T v, Dictionary<T, bool> visited)
        {
            Queue<T> queue = new Queue<T>();
            queue.Enqueue(v);

            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                Console.Write(v + " ");

                foreach (T i in adjList[v])
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }

        //DFS
        //Time complexity:O(V + E)
        public void DFS()
        {
            Dictionary<T, bool> visited = listToDictionary();

            foreach (T v in adjList.Keys)
            {
                if (!visited[v])
                    DFSUtil(v, visited);
            }
            Console.WriteLine();
        }


        void DFSUtil(T v, Dictionary<T, bool> visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (T i in adjList[v])
            {
                if (!visited[i])
                    DFSUtil(i, visited);
            }
        }

        //Topological Sort
        //Time complexity:O(V + E)
        public void TopologicalSort()
        {
            Stack<T> stack = new Stack<T>();
            Dictionary<T, bool> visited = listToDictionary();

            foreach (T v in adjList.Keys)
            {
                if (!visited[v])
                    TopologicalSortUtil(v, visited, stack);
            }

            foreach (T node in stack)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        void TopologicalSortUtil(T v, Dictionary<T, bool> visited, Stack<T> stack)
        {
            visited[v] = true;

            foreach (T node in adjList[v])
            {
                if (!visited[node])
                    TopologicalSortUtil(node, visited, stack);
            }
            stack.Push(v);
        }
    }




    // This class represents a directed graph
    // using adjacency Matrix
    public class AdjacencyMatrix
    {
        int[,] adjMatrix;
        int _v;

        //Constructor with a parameter v - number of vertices in a graph
        //Time complexity: O(v^2)
        public AdjacencyMatrix(int v)
        {
            adjMatrix = new int[v, v];
            _v = v;

            for (int i = 0; i < v; i++)
                for (int j = 0; j < v; j++)
                    adjMatrix[i, j] = 0;
        }

        // A function to add a Node
        //Time complexity: O(V^2)
        public void addNode(int x)
        {
            _v += x;
            int[,] adjMatrixTemp = new int[_v, _v];

            for (int i = 0; i < _v; i++)
                for (int j = 0; j < _v; j++)
                    adjMatrixTemp[i, j] = adjMatrix[i, j];
            adjMatrix = adjMatrixTemp;
        }

        // A function to add an edge with a weight
        //Time complexity: O(1)
        public void addEdge(int u, int v, int weight)
        {
            if (u >= _v || v >= _v)
                Console.WriteLine("Node does not exists!");
            if (u == v)
                Console.WriteLine("Same Node!");

            adjMatrix[u, v] = weight;
        }

        //BFS
        //Time complexity: O(v^2)
        public void BFS()
        {
            bool[] visited = new bool[_v];

            for (int i = 0; i < _v; i++)
            {
                if (visited[i] == false)
                    BFSUtil(i, visited);
            }
            Console.WriteLine();
        }

        void BFSUtil(int v, bool[] visited)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);

            while (queue.Count != 0)
            {
                v = queue.Dequeue();
                Console.Write(v + " ");

                for (int i = 0; i < _v; i++)
                {
                    if (adjMatrix[v, i] != 0 && !visited[i])
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
            bool[] visited = new bool[_v];

            for (int i = 0; i < _v; i++)
            {
                if (visited[i] == false)
                    DFSUtil(i, visited);
            }
        }

        void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            for (int i = 0; i < _v; i++)
            {
                if (adjMatrix[v, i] != 0 && !visited[i])
                    DFSUtil(i, visited);
            }
        }

        //Topological Sort
        //Time complexity: O(v^2)
        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            var visited = new bool[_v];

            for (int i = 0; i < _v; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            foreach (var Node in stack)
            {
                Console.Write(Node + " ");
            }
        }

        void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;

            for (int i = 0; i < _v; i++)
            {
                if (adjMatrix[v, i] != 0 && !visited[i])
                    TopologicalSortUtil(i, visited, stack);
            }
            stack.Push(v);
        }
    }
}
