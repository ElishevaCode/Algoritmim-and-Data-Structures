using System;
using System.Collections.Generic;
using System.Text;

namespace DataAlgoritmim
{
    class MinHeap<T>
    {
        static KeyValuePair<T, int>[] minHeap;
        static int size; // Saves the number of elements in the array

        //A function that accepts an array that is not a minimum heap and arranges it into a heap
        public static KeyValuePair<T, int>[] BuildHeap(KeyValuePair<T, int>[] arr)
        {
            minHeap = arr;
            size = arr.Length - 1;
            for (int i = Parent(size); i >= 0; i--)
            {
                SiftDoun(i);
            }
            return minHeap;
        }

        //A function that removes the root of the heap - the minimal element
        public static KeyValuePair<T, int> ExtractMin()
        {
            KeyValuePair<T, int> result = minHeap[0];
            minHeap[0] = minHeap[size];
            minHeap[size] = new KeyValuePair<T, int>(minHeap[size].Key, int.MinValue);
            size--;
            SiftDoun(0);
            return result;
        }

        //A function that changes the value of the element with a new value
        public static void ChangePriority(KeyValuePair<T, int> newNum)
        {
            int i;
            for (i = 0; i < minHeap.Length; i++)
            {
                if (minHeap[i].Key.Equals(newNum.Key))
                    break;
            }

            if (i < size + 1)
            {
                KeyValuePair<T, int> oldnum = minHeap[i];
                minHeap[i] = newNum;
                if (newNum.Value < oldnum.Value)
                    SiftUp(i);
                else
                    SiftDoun(i);
            }
        }

        //"Rolls" an element down
        private static void SiftDoun(int i)
        {
            KeyValuePair<T, int> temp;
            int maxIndex = 0;
            while (i <= size && ((LeftChild(i) <= size && minHeap[i].Value > minHeap[LeftChild(i)].Value) || (RightChild(i) <= size && minHeap[i].Value > minHeap[RightChild(i)].Value)))
            {
                if (LeftChild(i) <= size && minHeap[i].Value > minHeap[LeftChild(i)].Value)
                    maxIndex = LeftChild(i);
                if (RightChild(i) <= size && minHeap[RightChild(i)].Value < minHeap[maxIndex].Value)
                    maxIndex = RightChild(i);
                temp = minHeap[i];
                minHeap[i] = minHeap[maxIndex];
                minHeap[maxIndex] = temp;
                i = maxIndex;
            }
        }

        //"Rolls" an element up
        private static void SiftUp(int i)
        {
            while (Parent(i) >= 0 && (minHeap[i].Value == int.MinValue || minHeap[Parent(i)].Value > minHeap[i].Value))
            {
                KeyValuePair<T, int> temp = minHeap[Parent(i)];
                minHeap[Parent(i)] = minHeap[i];
                minHeap[i] = temp;
                i = Parent(i);
            }
        }

        //Returns the index of the parent
        private static int Parent(int i)
        {
            if (i == 0)
                return 0;
            if (i % 2 == 0)
                return i / 2 - 1;
            return i / 2;
        }

        //Returns the index of the left child
        private static int LeftChild(int i)
        {
            if (i == 0)
                return 1;
            return i * 2 + 1;
        }

        //Returns the index of the right child
        private static int RightChild(int i)
        {
            if (i == 0)
                return 2;
            return i * 2 + 2;
        }
    }
}

