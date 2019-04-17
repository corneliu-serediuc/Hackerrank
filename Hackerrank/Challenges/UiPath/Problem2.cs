using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank.Challenges.UiPath
{
    public partial class Solution
    {
        /*
        * Complete the 'distributeCandy' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts INTEGER_ARRAY score as parameter.
        */

        public static int DistributeCandy(List<int> score)
        {
            if (score == null || score.Count == 0)
            {
                return 0;
            }

            int[] candies = new int[score.Count];
            candies[0] = 1;

            // From let to right
            for (int i = 1; i < score.Count; i++)
            {
                if (score[i] > score[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
                else
                {
                    // If not ascending, assign 1
                    candies[i] = 1;
                }
            }

            int result = candies[score.Count - 1];

            // From right to left
            for (int i = score.Count - 2; i >= 0; i--)
            {
                int cur = 1;
                if (score[i] > score[i + 1])
                {
                    cur = candies[i + 1] + 1;
                }

                result += Math.Max(cur, candies[i]);
                candies[i] = cur;
            }

            return result;
        }

        /*
        private static void Main(string[] args)
        {
            int scoreCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> score = new List<int>();

            for (int i = 0; i < scoreCount; i++)
            {
                int scoreItem = Convert.ToInt32(Console.ReadLine().Trim());
                score.Add(scoreItem);
            }

            int result = DistributeCandy(score);

            Console.WriteLine(result);
        }
        */
    }
}
