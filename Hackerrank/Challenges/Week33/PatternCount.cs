using System;

namespace Hackerrank
{
    public partial class Solution
    {
        private static int PatternCount(string s)
        {
            int res = 0;
            int zeros = 0;
            bool goon = false;

            foreach (var c in s)
            {
                if (c == '1')
                {
                    if (goon && zeros > 0) res++;
                    goon = true;
                    zeros = 0;
                }
                else if (c == '0')
                {
                    if (goon) zeros++;
                }
                else
                {
                    if (goon)
                    {
                        goon = false;
                        zeros = 0;
                    }
                }
            }

            return res;
        }

        private static void Main(string[] args)
        {
            int res;

            string s = Console.ReadLine();

            res = PatternCount(s);

            Console.WriteLine(res);
        }
    }
}