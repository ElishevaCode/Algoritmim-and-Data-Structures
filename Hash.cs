using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DataAlgoritmim
{

    class Hash
    {

        //Exercises 
        //GeeksforGeeks

        //A function that puts the elements of the array into a dictionary
        //and counts how many identical elements there are in an array
        public static Dictionary<int, int> arrToDictionary(int[] arr)
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

        //1.
        //Given an array of size N with repeated numbers, You Have to Find the top three repeated numbers. 
        //Note : If Number comes same number of times then our output is one who comes first in array
        public static void top3Repeated(int[] arr)
        {
            if (arr.Length < 3)
            {
                Console.WriteLine("invalid!!!");
                return;
            }

            //Adding the elements of the array to the dictionary 
            Dictionary<int, int> dic = arrToDictionary(arr);

            //Create pairs for 3 maximum values
            KeyValuePair<int, int> max1 = new KeyValuePair<int, int>(int.MinValue, int.MinValue);
            KeyValuePair<int, int> max2 = new KeyValuePair<int, int>(int.MinValue, int.MinValue);
            KeyValuePair<int, int> max3 = new KeyValuePair<int, int>(int.MinValue, int.MinValue);

            //Transition on the dictionary to find the maximum 3 pairs
            foreach (var elem in dic)
            {
                if (elem.Value > max1.Value)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = new KeyValuePair<int, int>(elem.Key, elem.Value);
                }
                else if (elem.Value > max2.Value)
                {
                    max3 = max2;
                    max2 = new KeyValuePair<int, int>(elem.Key, elem.Value);
                }
                else if (elem.Value > max3.Value)
                {
                    max3 = new KeyValuePair<int, int>(elem.Key, elem.Value);
                }
            }

            //Printed the values
            Console.WriteLine("max1: "+max1+", max2: "+ max2 + ", max3: "+max3);

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

            //Adding the elements of the array to the dictionary 
            Dictionary<int, int> dic = arrToDictionary(arr1);

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
            Dictionary<int, int> dic = arrToDictionary(arr);

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
