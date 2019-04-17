using System;

namespace Hackerrank
{
    public partial class Solution
    {
        // Longest Palindromic Subsequence - Dynamic Programing - Recursive
        private static int LPSR(int[] seq, int i, int j, Graph graph)
        {
            // Base case 1
            if (i == j)
                return 1;

            // Base case 2
            if (seq[i] == seq[j] && i + 1 == j)
                return 2;

            // If the first and last characters match
            if (seq[i] == seq[j] || graph.IsReachable(seq[i], seq[j]))
                return LPSR(seq, i + 1, j - 1, graph) + 2;

            // If the first and last dont match
            return Math.Max(LPSR(seq, i, j - 1, graph), LPSR(seq, i + 1, j, graph));
        }

        private static int LPS(int[] seq, int m, Graph graph)
        {
            int i, j, cl;

            // Create a table to store results of subproblems
            int[,] L = new int[m, m];

            // Strings of length 1 are palindrome of lentgh 1
            for (i = 0; i < m; i++)
                L[i, i] = 1;

            // Build the table
            for (cl = 2; cl <= m; cl++)
            {
                for (i = 0; i < m - cl + 1; i++)
                {
                    j = i + cl - 1;
                    if (seq[i] == seq[j] && cl == 2)
                        L[i, j] = 2;
                    else if (seq[i] == seq[j] || graph.IsReachable(seq[i], seq[j]))
                        L[i, j] = L[i + 1, j - 1] + 2;
                    else
                        L[i, j] = Math.Max(L[i, j - 1], L[i + 1, j]);
                }
            }

            return L[0, m - 1];
        }

        /*
        private static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            int m = Convert.ToInt32(tokens_n[2]);

            var graph = new Graph(n);

            for (int a0 = 0; a0 < k; a0++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(tokens_x[0]);
                int y = Convert.ToInt32(tokens_x[1]);

                graph.AddEdge(x, y);
                graph.AddEdge(y, x);
            }

            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            // Iterative Longest Palindromic Subsequence
            Console.WriteLine(LPS(a, m, graph));

            // Recursive Longest Palindromic Subsequence - There is a problem
            // Console.WriteLine(LPSR(a, 0, m-1, graph));
        }
        */
    }
}