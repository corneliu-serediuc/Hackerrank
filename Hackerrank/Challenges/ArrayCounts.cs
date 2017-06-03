using System;
using System.Collections.Generic;

namespace Hackerrank
{
    public partial class Solution
    {
        /*
         * Amazon Online Test - Challenge 1 - Unfinished
         *
         * Array Counts
         *
         * Given two int arrays, nums (n length) and maxes (m length), output how many numbers exist in nums that are <= that each number in maxes.
         * Output is an int array of m length
         *
         */

        private static Node CreateBST(int[] a, int start, int end)
        {
            Node root = null;

            // Check
            if (start <= end)
            {
                // Partition the array and set the mid as root
                int mid = (start + end) / 2;
                root = new Node(a[mid]);

                // Generate and assign the left and right sub trees recursively
                if (start < end)
                {
                    root.left = CreateBST(a, start, mid - 1);
                    root.left = CreateBST(a, mid + 1, end);
                }
            }

            return root;
        }

        public static int InsertIntoBST(Node root, int data)
        {
            Node _newNode = new Node(data);
            Node _current = root;
            Node _previous = _current;

            var count = 0;

            while (_current != null)
            {
                if (data < _current.data)
                {
                    _previous = _current;
                    _current = _current.left;
                }
                else if (data > _current.data)
                {
                    _previous = _current;
                    _current = _current.right;
                }
                count++;
            }

            if (data < _previous.data)
                _previous.left = _newNode;
            else
                _previous.right = _newNode;

            return count;
        }

        private static int[] counts2(int[] nums, int[] maxes)
        {
            var n = nums.Length;
            var m = maxes.Length;

            // Deal with constraints
            if (n < 2 || n > 100000) throw new ArgumentOutOfRangeException("n");
            if (m < 2 || m > 100000) throw new ArgumentOutOfRangeException("m");

            // Easy solution (not the best complexity) - O(n x m)
            var result = new int[m];

            // Create the SortedSed
            var all = new SortedSet<int>();
            var maxesHash = new SortedSet<int>();
            for (int j = 0; j < n; j++) all.Add(nums[j]);

            for (int i = 0; i < m; i++) maxesHash.Add(maxes[i]);

            var counter = 0;
            foreach (var val in all)
            {
                if (maxesHash.Contains(val))
                {
                    maxesHash.Remove(val);
                    // result[counter] =
                }
            }

            return result;
        }

        private static int[] counts(int[] nums, int[] maxes)
        {
            var n = nums.Length;
            var m = maxes.Length;

            // Deal with constraints
            if (n < 2 || n > 100000) throw new ArgumentOutOfRangeException("n");
            if (m < 2 || m > 100000) throw new ArgumentOutOfRangeException("m");

            // Easy solution (not the best complexity) - O(n x m)

            var result = new int[m];
            for (int i = 0; i < m; i++)
            {
                if (maxes[i] < 1 || maxes[i] > 1000000000) throw new ArgumentOutOfRangeException("maxes[" + i + "]");

                int counter = 0;
                for (int j = 0; j < n; j++)
                {
                    if (nums[j] < 1 || nums[i] > 1000000000) throw new ArgumentOutOfRangeException("nums[" + j + "]");
                    if (maxes[i] >= nums[j]) counter++;
                }
                result[i] = counter;
            }

            return result;
        }

        /*
        private static void Main(String[] args)
        {
            // string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
            // TextWriter tw = new StreamWriter(@fileName, true);
            int[] res;

            int _nums_size = 0;
            _nums_size = Convert.ToInt32(Console.ReadLine());
            int[] _nums = new int[_nums_size];
            int _nums_item;
            for (int _nums_i = 0; _nums_i < _nums_size; _nums_i++)
            {
                _nums_item = Convert.ToInt32(Console.ReadLine());
                _nums[_nums_i] = _nums_item;
            }

            int _maxes_size = 0;
            _maxes_size = Convert.ToInt32(Console.ReadLine());
            int[] _maxes = new int[_maxes_size];
            int _maxes_item;
            for (int _maxes_i = 0; _maxes_i < _maxes_size; _maxes_i++)
            {
                _maxes_item = Convert.ToInt32(Console.ReadLine());
                _maxes[_maxes_i] = _maxes_item;
            }

            res = counts(_nums, _maxes);

            //for (int res_i = 0; res_i < res.Length; res_i++)
            //{
            //  tw.WriteLine(res[res_i]);
            //}

            // tw.Flush();
            // tw.Close();
        }
        */
    }
}