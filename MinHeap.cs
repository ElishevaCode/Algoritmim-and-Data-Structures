using System;
using System.Collections.Generic;
using System.Text;

namespace DataAlgoritmim
{
    class MinHeap<T>
    {
        static KeyValuePair<T, int>[] minHeap;
        static int size; // Saves the number of elements in the array

        public static KeyValuePair<T, int>[] BuildHeapFromArr(KeyValuePair<T, int>[] arr)
        {
            minHeap = arr;
            size = arr.Length - 1;

            orderMinHeap();

            return minHeap;
        }

        static void orderMinHeap()
        {
            for (int i = Parent(size); i >= 0; i--)
            {
                SiftDoun(i);
            }
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

        public static void ChangePriority(KeyValuePair<T, int> newNum)
        {
            int i = indexOfElement(newNum);
            if (i != -1)
            {
                int oldNum = minHeap[i].Value;
                minHeap[i] = newNum;
                if (newNum.Value < oldNum)
                    SiftUp(i);
                else
                    SiftDoun(i);
            }
        }

        static int indexOfElement(KeyValuePair<T, int> elem)
        {
            for (int i = 0; i < minHeap.Length; i++)
            {
                if (minHeap[i].Key.Equals(elem.Key))
                    return i;
            }
            return -1;
        }

        private static void SiftDoun(int i)
        {
            int maxIndex = 0;
            while (i <= size && ((LeftChild(i) <= size && minHeap[i].Value > minHeap[LeftChild(i)].Value) || (RightChild(i) <= size && minHeap[i].Value > minHeap[RightChild(i)].Value)))
            {
                if (LeftChild(i) <= size && minHeap[i].Value > minHeap[LeftChild(i)].Value)
                    maxIndex = LeftChild(i);
                if (RightChild(i) <= size && minHeap[RightChild(i)].Value < minHeap[maxIndex].Value)
                    maxIndex = RightChild(i);

                SwitchingBetween2Values(i, maxIndex);
                i = maxIndex;
            }
        }

        private static void SiftUp(int i)
        {
            while (Parent(i) >= 0 && (minHeap[i].Value == int.MinValue || minHeap[Parent(i)].Value > minHeap[i].Value))
            {
                SwitchingBetween2Values(Parent(i), i);
                i = Parent(i);
            }
        }

        private static void SwitchingBetween2Values(int index1, int index2)
        {
            KeyValuePair<T, int> temp;
            temp = minHeap[index1];
            minHeap[index1] = minHeap[index2];
            minHeap[index2] = temp;
        }

        private static int Parent(int i)
        {
            if (i == 0)
                return 0;
            if (i % 2 == 0)
                return i / 2 - 1;
            return i / 2;
        }

        private static int LeftChild(int i)
        {
            if (i == 0)
                return 1;
            return i * 2 + 1;
        }

        private static int RightChild(int i)
        {
            if (i == 0)
                return 2;
            return i * 2 + 2;
        }
    }
}

