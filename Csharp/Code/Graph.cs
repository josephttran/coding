using Code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    public class Graph
    {
        /* Given a reference of a node in a connected undirected graph.
         * Return a deep copy (clone) of the graph.
         * Each node in the graph contains a val (int) and a list (List[Node]) of its neighbors.
         * 
         * There is no repeated edges and no self-loops in the graph.
         */
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            List<Node> cloneNode = new List<Node>();

            while (q.Count > 0)
            {
                Node currNode = q.Dequeue();

                if (!visited.Contains(currNode))
                {
                    visited.Add(currNode);
                    cloneNode.Add(new Node(currNode.val));
                }

                foreach (Node neighbor in currNode.neighbors)
                {
                    if (!visited.Contains(neighbor))
                    {
                        q.Enqueue(neighbor);
                    }
                }
            }

            cloneNode.Sort((a, b) => a.val.CompareTo(b.val));

            foreach (Node currNode in visited)
            {
                cloneNode[currNode.val - 1].neighbors = new List<Node>();

                foreach (Node neighbor in currNode.neighbors)
                {
                    cloneNode[currNode.val - 1].neighbors.Add(cloneNode[neighbor.val - 1]);
                }
            }

            return cloneNode[0];
        }
    }
}
