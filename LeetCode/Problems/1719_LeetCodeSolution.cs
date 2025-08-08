using System;
using System.Collections.Generic;

// This class is designed to be dropped into a Visual Studio project and run from Program.cs or test harnesses.
// On LeetCode, rename the class to 'Solution' and remove the namespace for compatibility.

    /// <summary>
    /// LeetCode 1719 — Number of Ways to Reconstruct a Tree
    /// Returns 0 (impossible), 1 (unique), or 2 (multiple).
    /// </summary>
    public class Solution
    {
        // For LeetCode submission, change method signature to public int CheckWays(int[][] pairs) in a class named Solution
        public int CheckWays(int[][] pairs)
        {
            var adj = new Dictionary<int, HashSet<int>>();

            foreach (var p in pairs)
            {
                if (!adj.ContainsKey(p[0])) adj[p[0]] = new HashSet<int>();
                if (!adj.ContainsKey(p[1])) adj[p[1]] = new HashSet<int>();
                adj[p[0]].Add(p[1]);
                adj[p[1]].Add(p[0]);
            }

            int n = adj.Count;

            int root = -1;
            foreach (var node in adj.Keys)
            {
                if (adj[node].Count == n - 1)
                {
                    root = node;
                    break;
                }
            }
            if (root == -1) return 0;

            int res = 1;

            foreach (var node in adj.Keys)
            {
                if (node == root) continue;

                int parent = -1;
                int parentDegree = int.MaxValue;

                foreach (var neighbor in adj[node])
                {
                    int degN = adj[neighbor].Count;
                    int degNode = adj[node].Count;
                    if (degN >= degNode && degN < parentDegree)
                    {
                        parent = neighbor;
                        parentDegree = degN;
                    }
                }

                if (parent == -1) return 0;

                foreach (var neighbor in adj[node])
                {
                    if (neighbor == parent) continue;
                    if (!adj[parent].Contains(neighbor)) return 0;
                }

                if (adj[parent].Count == adj[node].Count) res = 2;
            }

            return res;
        }
    }
