namespace Hackerrank
{
    public partial class Solution
    {
        /* Game of Thrones
         *
         * Dothraki are planning an attack to usurp King Robert's throne.
         * King Robert learns of this conspiracy from Raven and plans to lock the single door through which the enemy can enter his kingdom.
         *
         * But, to lock the door he needs a key that is an anagram of a certain palindrome string.
         * The king has a string composed of lowercase English letters. Help him figure out whether any anagram of the string can be a palindrome or not.
         *
         * Input Format
         * A single line which contains the input string.
         *
         * Constraints
         * 1 < length of string < 10^5
         * Each character of the string is a lowercase English letter.
         *
         * Output Format
         * A single line which contains YES or NO in uppercase.
         */

        private const string YES = "YES";
        private const string NO = "NO";

        private static string CanBePalindrome(string str)
        {
            var length = str.Length;
            var freq = new int[26];

            // Get frequencies of each letter
            foreach (var c in str) freq[c - 'a']++;

            // Go through the English alphabet
            bool isFirst = true;
            for (int i = 0; i < 26; i++)
            {
                if (freq[i] % 2 != 0)
                {
                    if (length % 2 != 0 && isFirst) isFirst = false;
                    else return NO;
                }
            }

            return YES;
        }

        //private static void Main(String[] args)
        //{
        //    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        //    var str = Console.ReadLine();

        //    Console.WriteLine(CanBePalindrome(str));
        //}
    }
}