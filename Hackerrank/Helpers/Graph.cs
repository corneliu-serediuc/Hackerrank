using System.Collections.Generic;

namespace Hackerrank
{
    /// <summary>
    /// Represents a directed unweighted graph structure
    /// </summary>
    public class Graph
    {
        // Contains the child nodes for each vertex of the graph
        // assuming that the vertices are numbered 1 ... Size
        private HashSet<int>[] childNodes;

        /// <summary>Constructs an empty graph of given size</summary>
        /// <param name="size">number of vertices</param>
        public Graph(int size)
        {
            this.childNodes = new HashSet<int>[size + 1];
            for (int i = 1; i <= size; i++)
            {
                // Assing an empty list of adjacents for each vertex
                this.childNodes[i] = new HashSet<int>();
            }
        }

        /// <summary>Constructs a graph by given list of
        /// child nodes (successors) for each vertex</summary>
        /// <param name="childNodes">children for each node</param>
        public Graph(HashSet<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }

        /// <summary>
        /// Returns the size of the graph (number of vertices)
        /// </summary>
        public int Size
        {
            get { return this.childNodes.Length; }
        }

        /// <summary>Adds new edge from u to v</summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        public void AddEdge(int u, int v)
        {
            childNodes[u].Add(v);
        }

        /// <summary>Removes the edge from u to v if such exists
        /// </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        public void RemoveEdge(int u, int v)
        {
            childNodes[u].Remove(v);
        }

        public bool IsReachable(int u, int v)
        {
            if (u == v) return true;

            var visited = new HashSet<int>();

            var stack = new Stack<int>();
            stack.Push(u);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (vertex == v) return true;

                if (visited.Contains(vertex)) continue;

                visited.Add(vertex);

                foreach (var neighbor in GetSuccessors(vertex))
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return false;
        }

        /// <summary>
        /// Checks whether there is an edge between vertex u and v
        /// </summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        /// <returns>true if there is an edge between
        /// vertex u and vertex v</returns>
        public bool HasEdge(int u, int v)
        {
            bool hasEdge = childNodes[u].Contains(v);
            return hasEdge;
        }

        /// <summary>Returns the successors of a given vertex
        /// </summary>
        /// <param name="v">the vertex</param>
        /// <returns>list of all successors of vertex v</returns>
        public HashSet<int> GetSuccessors(int v)
        {
            return childNodes[v];
        }
    }
}