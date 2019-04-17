namespace Hackerrank
{
    public partial class Solution
    {
        // Complete the countingValleys function below.
        private static int CountingValleys(int n, string s)
        {
            if (n < 2 || n > 1000000 || n != s.Length)
            {
                return 0;
            }

            bool inValley = false;

            int result = 0;
            int path = 0;
            int[] ar = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                ar[i] = (s[i] == 'U') ? 1 : -1;
            }

            foreach (var step in ar)
            {
                path += step;

                if (path < 0 && !inValley)
                {
                    inValley = true;
                }

                if (path == 0 && inValley)
                {
                    result++;
                    inValley = false;
                }
            }

            return result;
        }

        /*
        private static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            int result = CountingValleys(n, s);

            Console.WriteLine(result);
        }
        */
    }
}