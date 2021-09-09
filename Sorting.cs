using System;
using System.Collections.Generic;
using System.Text;

namespace DataAlgoritmim
{
    class Sorting
    {
        //Bubble Sort
        //Time complexity: O(N^2)
        public static void BubbleSort(int[] arr)
        {
            bool flag = true;
            int temp;
            for (int i = 0; i < arr.Length && flag; i++)
            {
                flag = false;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }

        //Merge Sort
        //Time complexity: O(N*Log(N))
        public static void MergeSort(int[] arr)
        {
            sort(arr, 0, arr.Length - 1);
        }

        static void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                sort(arr, l, m);
                sort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }

        static void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }


        //Quick Sort
        //Time complexity: avg( O(N*Log(N)) )
        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        static void QuickSort(int[] arr, int l, int r)
        {
            int i;
            if (l < r)
            {
                i = Partition(arr, l, r);

                QuickSort(arr, l, i - 1);
                QuickSort(arr, i + 1, r);
            }
        }

        static int Partition(int[] arr, int l, int r)
        {
            int temp;
            int p = arr[r];
            int i = l - 1;

            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[r];
            arr[r] = temp;
            return i + 1;
        }


        //Binary Search (on a sorted array)
        //Time complexity: O(Log(N))
        public static int BSA(int[] arr,int x)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                if (arr[m] == x)
                    return m;

                if (arr[m] < x)
                    l = m + 1;

                else
                    r = m - 1;
            }
            return -1;
        }
    }
}
