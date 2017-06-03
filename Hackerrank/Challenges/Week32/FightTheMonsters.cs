using System;

namespace Hackerrank
{
    public partial class Solution
    {
        /*
         * Hackerrank - Week of Code 32 - Problem 2
         *
         * Fight the Monsters!
         *
         * Jason is trapped in a forest with n hungry monsters and must use his trusty blaster to defend himself! Each monster i has a health value, h(i). Jason can discharge his blaster at a monster once per second and reduce its health points by "hit" units. Once a monster's health points become <= 0, it dies.
         * Given the health values for each monster and an integer, t, can you determine the maximum number of monsters he can kill in t seconds? Assume Jason always hits his target!
         *
         * Input Format
         * The first line consists of three space-separated integers describing the respective values of n, "hit" and t.
         * The second line consists of n space-separated integers describing the values of h0, h1, ... h(n-1).
         *
         * Output Format
         * Print an integer denoting the maximum number of monsters Jason can kill in t seconds.
         */

        private static int getMaxMonsters(int n, int hit, int t, int[] h)
        {
            int x = (23 + hit - 1) / hit;

            Console.WriteLine(x);

            // 0. Check for marginal cases
            if (n <= 0 || n > 100000) throw new ArgumentOutOfRangeException("n");
            if (hit <= 0 || hit > 1000000000) throw new ArgumentOutOfRangeException("hit");
            if (t <= 0 || t > 1000000000) throw new ArgumentOutOfRangeException("t");

            // 1. How many hits are needed to exterminate each monster
            for (int i = 0; i < n; i++)
            {
                if (h[i] <= 0 || h[i] > 1000000000) throw new ArgumentOutOfRangeException("h[" + i + "]");
                h[i] = (h[i] + hit - 1) / hit;
            }

            // 2. Sort the array
            Array.Sort<int>(h);

            // 3. See how many we can kill
            int kills = 0;
            for (int i = 0; i < n; i++)
            {
                if (t < h[i]) break;
                kills++;
                t = t - h[i];
            }

            return kills;
        }

        /*
       static void Main(String[] args)
       {
           string[] tokens_n = Console.ReadLine().Split(' ');
           int n = Convert.ToInt32(tokens_n[0]);
           int hit = Convert.ToInt32(tokens_n[1]);
           int t = Convert.ToInt32(tokens_n[2]);
           string[] h_temp = Console.ReadLine().Split(' ');
           int[] h = Array.ConvertAll(h_temp, Int32.Parse);
           int result = getMaxMonsters(n, hit, t, h);
           Console.WriteLine(result);
       }
       */
    }
}