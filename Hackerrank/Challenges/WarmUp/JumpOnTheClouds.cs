using System;

namespace Hackerrank
{
    internal class JumpOnTheClouds
    {
        // Complete the jumpingOnClouds function below.
        private static int JumpingOnClouds(int[] clouds)
        {
            int noOfJumps = 0, i = 0;

            while (true)
            {
                if (i + 2 < clouds.Length && clouds[i + 2] == 0)
                {
                    i += 2;
                }
                else if (i + 1 < clouds.Length)
                {
                    i++;
                }
                else
                {
                    break;
                }
                noOfJumps++;
            }

            return noOfJumps;
        }

        /*
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = JumpingOnClouds(c);

            Console.WriteLine(result);
        }
        */
    }
}