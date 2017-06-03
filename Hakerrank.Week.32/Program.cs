using System;
using System.Collections.Generic;

namespace Hakerrank.Week._32
{
    internal class Program
    {
        /*
        static void Main(string[] args)
        {
            int hit = 8;
            int time = 6;

            int x = (16 + hit - 1) / hit;
            // var n = Math.Round(x);

            Console.WriteLine(x);

            int V, n;

            string line = Console.ReadLine();
            while (!int.TryParse(line, out n) || n < 1 || n > 1000)
            {
                Console.WriteLine("Please insert a number between 1 and 1000.");
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (!int.TryParse(line, out V) || V < -1000 || V > 1000)
            {
                Console.WriteLine("Please insert a number between -1000 and 1000.");
                Console.ReadLine();
            }

            int[] ar = new int[n];
    }
     */

        /* Hackerrank - Week of Code 32 - Problem 1

        // static List<int> powersOfTwo = new List<int>() { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
        static List<int> powersOfTwo = new List<int>() { 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };

        static string duplication(int x)
        {
            // Complete this function

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
            if (duplication(x - pot) == "0") return "1";
            else return "0";
        }

        static void Main(String[] args)
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

        /*
        // Hackerrank - Week of Code 32 - Problem 2
        static int getMaxMonsters(int n, int hit, int t, int[] h)
        {
            int x = (23 + hit - 1) / hit;

            Console.WriteLine(x);

            // 0. Check for marginal cases
            if (n <= 0 || n>100000) throw new ArgumentOutOfRangeException("n");
            if (hit <= 0 || hit > 1000000000) throw new ArgumentOutOfRangeException("hit");
            if (t <= 0 || t > 1000000000) throw new ArgumentOutOfRangeException("t");

            // 1. How many hits are needed to exterminate each monster
            for (int i = 0; i < n; i++)
            {
                if (h[i] <= 0 || h[i] > 1000000000) throw new ArgumentOutOfRangeException("h["+i+"]");
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

        // Circular Walk
        /*
        private static int circularWalk(int n, int s, int t, int r_0, int g, int seed, int p)
        {
            // Treat marginal cases
            if (n < 1 || n > 10000000) throw new ArgumentOutOfRangeException("n");
            if (s < 0 || s >= n) throw new ArgumentOutOfRangeException("s");
            if (t < 0 || t >= n) throw new ArgumentOutOfRangeException("t");
            if (p < 1 || s > n) throw new ArgumentOutOfRangeException("p");
            if (r_0 < 0 || r_0 >= p) throw new ArgumentOutOfRangeException("r_0");
            if (g < 0 || g >= p) throw new ArgumentOutOfRangeException("g");
            if (seed < 0 || seed >= p) throw new ArgumentOutOfRangeException("seed");

            // Calculate the R dictionary
            CalculateR(n, r_0, g, seed, p);

            // Create the LinkedList for the nodes
            var nodeList = new LinkedList<int>();
            var firstNode = new LinkedListNode<int>(0);
            nodeList.AddFirst(firstNode);

            var currentNode = firstNode;
            for (int i = 1; i < n; i++)
            {
                currentNode = nodeList.AddAfter(currentNode, i);
            }

            // Build the adjacency matrix of the directed, unweighted graph
            int[,] adj = new int[n, n];
            currentNode = firstNode;
            while (currentNode != null)
            {
                var theR = R[currentNode.Value];
                var currNext = currentNode.NextOrFirst();
                var currPrev = currentNode.PreviousOrLast();

                while (theR > 0)
                {
                    adj[currentNode.Value, currNext.Value] = 1;
                    adj[currentNode.Value, currPrev.Value] = 1;

                    currNext = currNext.NextOrFirst();
                    currPrev = currPrev.PreviousOrLast();

                    theR--;
                }

                currentNode = currentNode.Next;
            }

            // Create the directed graph with Node
            graph = new Dictionary<int, Node<int>>(n);
            for (int i = 0; i < n; i++) graph[i] = new Node<int>(i);

            currentNode = firstNode;
            while (currentNode != null)
            {
                var theR = R[currentNode.Value];
                var currNext = currentNode.NextOrFirst();
                var currPrev = currentNode.PreviousOrLast();

                while (theR > 0)
                {
                    graph[currentNode.Value].AddLink(graph[currNext.Value]);
                    graph[currentNode.Value].AddLink(graph[currPrev.Value]);

                    currNext = currNext.NextOrFirst();
                    currPrev = currPrev.PreviousOrLast();

                    theR--;
                }

                currentNode = currentNode.Next;
            }

            // Print it
            // PrintMatrixNice(adj);

            // Run the Dijkstra algorithm for the shortest path
            // ShortestPath(adj, s, n);

            // Run BFS on a directed graf
            return BFSdirected(s, t, n);

            // return dist[t];
        }

        private static Dictionary<int, int> R;
        private static List<int> list = new List<int>();
        private static int[] dist;

        private static Dictionary<int, Node<int>> graph;
        private static Queue<int> queue = new Queue<int>();

        public static void Init(int s, int n)
        {
            dist = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                list.Add(i);
            }

            dist[s] = 0;
        }

        private static int GetNextVertex()
        {
            var min = int.MaxValue;
            int vertex = -1;

            foreach (int val in list)
            {
                if (dist[val] <= min)
                {
                    min = dist[val];
                    vertex = val;
                }
            }

            list.Remove(vertex);
            return vertex;
        }

        private static void PrintMatrixNice(int[,] adj)
        {
            int rowLength = adj.GetLength(0);
            int colLength = adj.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", adj[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.ReadLine();
        }

        private static void ShortestPath(int[,] adj, int start, int n)
        {
            Init(start, n);

            while (list.Count > 0)
            {
                int u = GetNextVertex();
                for (int i = 0; i < n; i++)
                {
                    if (adj[u, i] > 0)
                    {
                        if (dist[i] > dist[u] + adj[u, i])
                        {
                            dist[i] = dist[u] + adj[u, i];
                        }
                    }
                }
            }
        }

        private static int BFSdirected(int start, int finish, int n)
        {
            queue.Enqueue(start);
            int[] level = new int[n];
            level[start] = 0;

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                foreach (var link in graph[curr].Links)
                {
                    level[link.Value] = level[curr] + 1;
                    if (link.Value == finish) return level[link.Value];
                    queue.Enqueue(link.Value);
                }
            }

            return -1;
        }

        private static void CalculateR(int n, int r_0, int g, int seed, int p)
        {
            R = new Dictionary<int, int>(n) { [0] = r_0 };

            for (int i = 1; i < n; i++)
            {
                R[i] = (R[i - 1] * g + seed) % p;
            }
        }

        private static void BuildDirectedGraph(int[,] adj, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= R[i]; j++)
                {
                }
            }
        }

        private static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int s = Convert.ToInt32(tokens_n[1]);
            int t = Convert.ToInt32(tokens_n[2]);
            string[] tokens_r_0 = Console.ReadLine().Split(' ');
            int r_0 = Convert.ToInt32(tokens_r_0[0]);
            int g = Convert.ToInt32(tokens_r_0[1]);
            int seed = Convert.ToInt32(tokens_r_0[2]);
            int p = Convert.ToInt32(tokens_r_0[3]);
            int result = circularWalk(n, s, t, r_0, g, seed, p);
            Console.WriteLine(result);
        }
        */

        /*
    // Geometric Trick
    private static List<int> PrimeFactors(int x)
    {
        var result = new List<int>();

        for (int i = 2; i < Math.Sqrt(x); i++)
        {
            if (x % i == 0)
            {
                while (x % i == 0)
                {
                    x = x / i;
                    result.Add(i);
                }
            }
        }

        if (x != 1) result.Add(x);

        return result;
    }

    private static List<int> FindFactors(int num)
    {
        List<int> result = new List<int>();

        // Take out the 2s.
        while (num % 2 == 0)
        {
            result.Add(2);
            num /= 2;
        }

        // Take out other primes.
        int factor = 3;
        while (factor * factor <= num)
        {
            if (num % factor == 0)
            {
                // This is a factor.
                result.Add(factor);
                num /= factor;
            }
            else
            {
                // Go to the next odd number.
                factor += 2;
            }
        }

        // If num is not 1, then whatever is left is prime.
        if (num > 1)
        {
            result.Add(num);
        }

        return result;
    }

    private static int geometricTrick(string s)
    {
        var n = s.Length;
        int result = 0;

        for (int p = 2; p < n && p < 710; p++)
        {
            if (s[p] == 'b')
            {
                var sq = (p + 1) * (p + 1);

                for (int q = 1; q < p + 1; q++)
                {
                    if (sq % q == 0)
                    {
                        var term1 = q;
                        var term2 = sq / q;

                        if (term1 <= n && term2 <= n)
                        {
                            if (s[term1 - 1] == 'a' && s[term2 - 1] == 'c') result++;
                            if (s[term1 - 1] == 'c' && s[term2 - 1] == 'a') result++;
                        }
                    }
                }
            }
        }

        return result;
    }

    private static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        int result = geometricTrick(s);
        Console.WriteLine(result);

        foreach (var val in FindFactors(1296)) Console.Write(val.ToString() + ", ");
    }
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
            foreach(var val in all)
            {
                if(maxesHash.Contains(val))
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

        /*
        private static void Main(String[] args)
        {
            int[] res;

            int _a_size = 0;
            _a_size = Convert.ToInt32(Console.ReadLine());
            string[] _a = new string[_a_size];
            string _a_item;
            for (int _a_i = 0; _a_i < _a_size; _a_i++)
            {
                _a_item = Console.ReadLine();
                _a[_a_i] = _a_item;
            }

            int _b_size = 0;
            _b_size = Convert.ToInt32(Console.ReadLine());
            string[] _b = new string[_b_size];
            string _b_item;
            for (int _b_i = 0; _b_i < _b_size; _b_i++)
            {
                _b_item = Console.ReadLine();
                _b[_b_i] = _b_item;
            }

            res = getMinimumDifference(_a, _b);
        }
        */

        private static int[] getMinimumDifference(string[] a, string[] b)
        {
            // Deal with limitations

            // We already know that the length of the two string array is the same
            var n = a.Length;
            var result = new int[n];

            for (int i = 0; i < n; i++)
            {
                // Marginal case
                if (a[i].Length != b[i].Length)
                {
                    result[i] = -1;
                    continue;
                }

                var c1 = new int[26];
                var c2 = new int[26];

                // Get frequencies of letters in string 1
                foreach (char c in a[i]) c1[c - 'a']++;

                // Get frequencies of letters in string 2
                foreach (char c in b[i]) c2[c - 'a']++;

                // Go through the lowercase english alphabet
                int count = 0;
                for (int j = 0; j < 26; j++)
                    count += Math.Abs(c1[j] - c2[j]);

                result[i] = count;
            }

            return result;
        }
    }
}

public static class CircularLinkedList
{
    public static LinkedListNode<int> NextOrFirst(this LinkedListNode<int> current)
    {
        if (current.Next == null)
            return current.List.First;
        return current.Next;
    }

    public static LinkedListNode<int> PreviousOrLast(this LinkedListNode<int> current)
    {
        if (current.Previous == null)
            return current.List.Last;
        return current.Previous;
    }
}

internal class Node
{
    public int data;
    public Node left, right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

public class Node<T>
{
    public int Value;
    public int Depth;
    public List<Node<T>> Links;

    public Node(int value)
    {
        this.Value = value;
        Links = new List<Node<T>>();
    }

    public void AddLink(Node<T> node)
    {
        Links.Add(node);
    }

    public void RemoveLink(Node<T> node)
    {
        Links.Remove(node);
    }
}