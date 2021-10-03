using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace DataAlgoritmim
{

    class Hash
    {

        //Exercises 
        //GeeksforGeeks

        //A function that puts the elements of the array into a dictionary
        //and counts how many identical elements there are in an array
        static Dictionary<int, int> ConvertArrToDictionary(int[] arr)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var i in arr)
            {
                if (dic.ContainsKey(i))
                    dic[i]++;
                else
                    dic.Add(i, 1);
            }
            return dic;
        }

        static int maxElement(Dictionary<int, int> dic)
        {
            int max = int.MinValue;
            int valueMax = 0;
            foreach (var item in dic)
            {
                if (item.Value > valueMax)
                {
                    valueMax = item.Value;
                    max = item.Key;
                }
            }
            dic[max] = 0;
            return max;
        }

        static int getMaxKey(Dictionary<int,int> dic)
        {
            return dic.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        //1.
        //Given an array of size N with repeated numbers, You Have to Find the top three repeated numbers. 
        //Note : If Number comes same number of times then our output is one who comes first in array
        public static void topXRepeated(int[] arr,int x)
        {
            if (arr.Length < x)
            {
                Console.WriteLine("invalid!");
                return;
            }

            Dictionary<int, int> dic = ConvertArrToDictionary(arr);

            List<int> listOfMax = new List<int>();
            int max;

            for (int i = 0; i < x; i++)
            {
                max = getMaxKey(dic);
                dic[max] = 0;
                listOfMax.Add(max);
            }

            printList(listOfMax);
        }

        static void printList(List<int> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine(i + " ");
            }
        }

        //2.
        //Given two given arrays of equal length,
        //the task is to find if given arrays are equal or not.
        //Two arrays are said to be equal if both of them contain the same set of elements,
        //arrangements (or permutation) of elements may be different though.
        public static bool areEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;

            Dictionary<int, int> dic = ConvertArrToDictionary(arr1);

            //Comparing 2 arrays 
            //checking - if have a values in the dictionary thats not equal to zero,
            //means that arrays not equal
            foreach (var i in arr2)
            {
                if (dic.ContainsKey(i))
                {
                    if (dic[i] == 0)
                        return false;
                    dic[i]--;
                }
                else
                    return false;
            }
            return true;
        }

        //3.
        //Given an array of n integers, find the sum of f(a[i], a[j]) of all pairs (i, j) such that (1 <= i < j <= n). 
        //Copied from GeeksforGeeks
        public static int sum(int[] a, int n)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            int ans = 0, pre_sum = 0;
            for (int i = 0; i < n; i++)
            {
                ans += (i * a[i]) - pre_sum;
                pre_sum += a[i];

                if (dic.ContainsKey(a[i] - 1))
                {
                    ans -= dic[a[i] - 1];
                }

                if (dic.ContainsKey(a[i] + 1))
                {
                    ans += dic[a[i] + 1];
                }

                if (dic.ContainsKey(a[i]))
                {
                    dic[a[i]] = dic[a[i]] + 1;
                }
                else
                {
                    dic[a[i]] = 1;
                }
            }
            return ans;
        }

        //4.
        //Given an array of n elements.The task is to count the total number of indices (i, j) such that arr[i] = arr[j] and i != j
        public static int countPairs(int[] arr)
        {
            Dictionary<int, int> dic = ConvertArrToDictionary(arr);

            int sumOfPairs = 0;

            //Calculation of invoice series amount
            //For each element found more than once in the array
            foreach (var v in dic.Values)
            {
                if (v > 1)
                    sumOfPairs += v * (v - 1) / 2;
            }
            return sumOfPairs;
        }

    }

}
