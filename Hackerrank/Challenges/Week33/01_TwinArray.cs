using System;

namespace Hackerrank
{
    public partial class Solution
    {
        public static int twinArrays(int[] ar1, int[] ar2)
        {
            int n = ar1.Length;

            int mina1, mina2, minb1, minb2;
            int pa1 = -1, pa2 = -1, pb1 = -1, pb2 = -1;

            mina1 = mina2 = minb1 = minb2 = int.MaxValue;

            // Get the first min
            for (int i = 0; i < n; i++)
            {
                // In first array - a
                if (ar1[i] < mina1)
                {
                    mina1 = ar1[i];
                    pa1 = i;
                }

                // In second array - b
                if (ar2[i] < minb1)
                {
                    minb1 = ar2[i];
                    pb1 = i;
                }
            }

            // Get the second min
            for (int i = 0; i < n; i++)
            {
                // In first array - a
                if (ar1[i] < mina2 && pa1 != i)
                {
                    mina2 = ar1[i];
                    pa2 = i;
                }

                // In second array - b
                if (ar2[i] < minb2 && pb1 != i)
                {
                    minb2 = ar2[i];
                    pb2 = i;
                }
            }

            int res = int.MaxValue;

            if (pa1 != pb1) res = mina1 + minb1;
            else
            {
                int temp1 = mina1 + minb2;
                int temp2 = mina2 + minb1;

                if (temp1 < temp2) res = temp1;
                else res = temp2;
            }

            return res;
        }

        /*
        private static void Main(string[] args)
        {
            int res;

            int n = 0;
            n = Convert.ToInt32(Console.ReadLine());

            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            string[] b_temp = Console.ReadLine().Split(' ');
            int[] b = Array.ConvertAll(b_temp, Int32.Parse);

            res = twinArrays(a, b);

            Console.WriteLine(res);
        }
        */
    }
}