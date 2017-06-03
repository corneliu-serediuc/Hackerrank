using System;

namespace Hackerrank
{
    public partial class Solution
    {
        /*
         * Amazon Online Test - Challenge 2
         *
         * Anagram Difference
         *
         * Given two strings, get the minimum number of changes in one string so that it becomes an anagram of the second.
         * A string is an anagram on another if they contain the same letter, but positions are mixed.
         *
         */

        private static int[] getMinimumDifference(string[] a, string[] b)
        {
            // Deal with limitations

            // We already know that the length of the two string array is the same
            var n = a.Length;
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                // Marginal case
                if (a[i].Length != b[i].Length)
                {
                    result[i] = -1;
                    continue;
                }

                var c1 = new int[26];
                var c2 = new int[26];

                // Get frequencies of letters in string 1
                foreach (char c in a[i]) c1[c - 'a']++;

                // Get frequencies of letters in string 2
                foreach (char c in b[i]) c2[c - 'a']++;

                // Go through the lowercase english alphabet
                int count = 0;
                for (int j = 0; j < 26; j++)
                    count += Math.Abs(c1[j] - c2[j]);

                result[i] = count;
            }

            return result;
        }

        /*
        private static void Main(String[] args)
        {
            int[] res;

            int _a_size = 0;
            _a_size = Convert.ToInt32(Console.ReadLine());
            string[] _a = new string[_a_size];
            string _a_item;
            for (int _a_i = 0; _a_i < _a_size; _a_i++)
            {
                _a_item = Console.ReadLine();
                _a[_a_i] = _a_item;
            }

            int _b_size = 0;
            _b_size = Convert.ToInt32(Console.ReadLine());
            string[] _b = new string[_b_size];
            string _b_item;
            for (int _b_i = 0; _b_i < _b_size; _b_i++)
            {
                _b_item = Console.ReadLine();
                _b[_b_i] = _b_item;
            }

            res = getMinimumDifference(_a, _b);
        }
        */
    }
}