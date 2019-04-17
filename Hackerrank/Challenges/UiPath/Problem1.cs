using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank
{
    public partial class Solution
    {
        /*
     * Complete the 'getMaxElementIndexes' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY rotate
     */

        public static List<int> GetMaxElementIndexes(List<int> a, List<int> rotate)
        {
            if (a.Count == 0 || rotate.Count == 0) return new List<int>();

            var maxValue = GetMax(a);
            var result = new List<int>();

            foreach(var r in rotate)
            {
                var temp = a.ToArray();
                var n = temp.Length;

                LeftRotate2(temp, r, n);

                result.Add(GetIndiceFor(temp, maxValue));
            }

            return result;
        }
        static void LeftRotate(int[] arr, int d, int n)
        {
            d = d % n;

            for (int i = 0; i < d; i++)
                LeftRotatebyOne(arr, n);
        }

        static void LeftRotatebyOne(int[] arr, int n)
        {
            int i, temp = arr[0];
            for (i = 0; i < n - 1; i++)
                arr[i] = arr[i + 1];

            arr[i] = temp;
        }

        static int GetMax(List<int> list)
        {
            if (list.Count == 0) return default(int);

            int max = int.MinValue;

            foreach(var val in list)
            {
                if (val > max) max = val;
            }

            return max;
        }

        static int GetIndiceFor(int[] arr, int val)
        {
            for (int i = 0; i < arr.Length; i++) if (arr[i] == val) return i;

            return default(int);
        }

        static void LeftRotate2(int[] arr, int d, int n)
        {
            int i, j, k, temp;

            d = d % n;

            for (i = 0; i < GCD(d, n); i++)
            {
                /* move i-th values of blocks */
                temp = arr[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= n)
                        k = k - n;
                    if (k == i)
                        break;
                    arr[j] = arr[k];
                    j = k;
                }
                arr[j] = temp;
            }
        }
        static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return GCD(b, a % b);
        }

        /*
        private static void Main(string[] args)
        {
            int aCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = new List<int>();

            for (int i = 0; i < aCount; i++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine().Trim());
                a.Add(aItem);
            }

            int rotateCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> rotate = new List<int>();

            for (int i = 0; i < rotateCount; i++)
            {
                int rotateItem = Convert.ToInt32(Console.ReadLine().Trim());
                rotate.Add(rotateItem);
            }

            List<int> result = GetMaxElementIndexes(a, rotate);

            Console.WriteLine(String.Join("\n", result));
        }
        */
    }
}
