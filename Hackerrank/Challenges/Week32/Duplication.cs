using System;
using System.Collections.Generic;

namespace Hackerrank
{
    public partial class Solution
    {
        /*
         * Hackerrank - Week of Code 32 - Problem 1
         *
         * Duplication
         *
         */

        private static List<int> powersOfTwo = new List<int>() { 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };

        private static string Duplication(int x)
        {
            // 1. Check for boundries
            if (x < 0 || x > 1000) throw new ArgumentOutOfRangeException("x");

            // 2. Return condition
            if (x == 0) return "0";
            if (x == 1) return "1";
            if (x == 2) return "1";
            if (x == 3) return "0";

            // 3. The rule

            // 3a Find the power of 2 smaller than x
            int pot = 0;
            foreach (var v in powersOfTwo)
                if (v <= x)
                {
                    pot = v;
                    break;
                }

            // 3b Return not of the difference
            if (Duplication(x - pot) == "0") return "1";
            else return "0";
        }

        /*
        public static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                int x = Convert.ToInt32(Console.ReadLine());
                string result = duplication(x);
                Console.WriteLine(result);
            }
        }
        */
    }
}