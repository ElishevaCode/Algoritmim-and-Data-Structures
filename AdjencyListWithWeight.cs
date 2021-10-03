using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAlgoritmim
{
    class AdjencyListWithWeight<T>
    {
        Dictionary<T, LinkedList<KeyValuePair<T, int>>> adjList;

        public AdjencyListWithWeight()
        {
            adjList = new Dictionary<T, LinkedList<KeyValuePair<T, int>>>();
        }

        //Time complexity: O(V)
        public void addNode(T data)
        {
            adjList.Add(data, new LinkedList<KeyValuePair<T, int>>());
        }

        //Time complexity: O(1)
        public void addEdge(T u, T v, int weight)
        {
            adjList[u].AddLast(new KeyValuePair<T, int>(v, weight));
            adjList[v].AddLast(new KeyValuePair<T, int>(u, weight));
        }

        public Dictionary<T, int> dijkstra(T source, T target)
        {
            Dictionary<T, int> distancesFromSource = adjList.ToDictionary(k => k.Key, v => int.MaxValue);
            Dictionary<T, T> NamesOfCitiesToTravel = adjList.ToDictionary(k => k.Key, v => v.Key);

            distancesFromSource[source] = 0;

            KeyValuePair<T, int>[] heap = MinHeap<T>.BuildHeap(distancesFromSource.ToArray());

            while (heap[0].Value != int.MinValue)
            {
                KeyValuePair<T, int> u = MinHeap<T>.ExtractMin();
                foreach (var v in adjList[u.Key])
                {
                    if (distancesFromSource[v.Key] > distancesFromSource[u.Key] + whight(u.Key, v.Key))
                    {
                        distancesFromSource[v.Key] = distancesFromSource[u.Key] + whight(u.Key, v.Key);
                        NamesOfCitiesToTravel[v.Key] = u.Key;
                        MinHeap<T>.ChangePriority(v);
                    }
                }
            }

            printWayFromSourceToTarget(source, target, NamesOfCitiesToTravel);
            return distancesFromSource;
        }

        void printWayFromSourceToTarget(T source, T target, Dictionary<T, T> NamesOfCitiesToTravel)
        {
            Console.Write("the way is: " + target + " --> ");
            T city = NamesOfCitiesToTravel[target];

            while (!city.Equals(source))
            {
                Console.Write(city + " --> ");
                city = NamesOfCitiesToTravel[city];
            }
            Console.Write(city);
            Console.WriteLine();
        }

        int whight(T u, T v)
        {
            KeyValuePair<T, int> whightV = adjList[u].Where(x => x.Key.Equals(v)).FirstOrDefault();
            return whightV.Value;
        }

        public void minDistanceFromUtoV(T u, T v)
        {
            Dictionary<T, int> dic = dijkstra(u, v);
            Console.WriteLine("the distance from " + u + " to " + v + " is: " + dic[v]);
        }
    }
}
