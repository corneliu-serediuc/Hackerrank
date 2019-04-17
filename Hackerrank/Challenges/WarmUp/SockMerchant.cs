using System;
using System.Collections.Generic;
using System.IO;

namespace Hackerrank
{
    public partial class Solution
    {
        // Complete the sockMerchant function below.
        private static int sockMerchant(int n, int[] ar)
        {
            if (n <= 0 || ar.Length <= 1) return 0;

            Dictionary<int, int> freq = new Dictionary<int, int>();

            int result = 0;

            foreach(var pair in ar)
            {
                if (freq.ContainsKey(pair)) freq[pair]++;
                else freq.Add(pair, 1);

                if(freq[pair] == 2)
                {
                    result++;
                    freq[pair] = 0;
                }
            }

            return result;
        }

        /*
        private static void Main(string[] args)
        {
            // TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int result = sockMerchant(n, ar);

            Console.WriteLine(result);

            // textWriter.WriteLine(result);

            // textWriter.Flush();
            // textWriter.Close();
        }
        */
    }
}