using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    #region Problem Description
    
    //You are given an array pairs, where pairs[i] = [xi, yi], and:

    //There are no duplicates.
    //xi<yi
    //Let ways be the number of rooted trees that satisfy the following conditions:

    //The tree consists of nodes whose values appeared in pairs.
    //A pair [xi, yi] exists in pairs if and only if xi is an ancestor of yi or yi is an ancestor of xi.
    //Note: the tree does not have to be a binary tree.
    //Two ways are considered to be different if there is at least one node that has different parents in both ways.

    //Return:

    //0 if ways == 0
    //1 if ways == 1
    //2 if ways > 1
    //A rooted tree is a tree that has a single root node, and all edges are oriented to be outgoing from the root.

    //An ancestor of a node is any node on the path from the root to that node (excluding the node itself). The root has no ancestors.

    #endregion

    internal class _1719_NumberOfWaysToReconstructATree
    {
        public void Run()
        {
            var pairs = new int[][] // Example 2 from the problem description
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 1, 3 }
            };

            var result = checkTree(pairs);
            Console.WriteLine($"[1719] Number of Ways to Reconstruct a Tree: {result}");
        }

        public int checkTree(int[][] pairs)
        {
            var pairDict = new Dictionary<int, HashSet<int>>();

            // Build the dictionary from pairs
            foreach ( var pair in pairs )
            {
                if (!pairDict.ContainsKey(pair[0])) 
                    pairDict[pair[0]] = new HashSet<int>();  // If Pair Dictionary does not contain the first element, add it with an empty HashSet
                if (!pairDict.ContainsKey(pair[1]))
                    pairDict[pair[1]] = new HashSet<int>(); // If Pair Dictionary does not contain the second element, add it with an empty HashSet
                pairDict[pair[0]].Add(pair[1]); // Add the second element to the HashSet of the first element
                pairDict[pair[1]].Add(pair[0]); // Add the first element to the HashSet of the second element

                // This ensures that elements are added based on whether or not they are already present in the dictionary.
            }

            int n = pairDict.Count; // Get the number of unique nodes

            // Find Root: Connect all nodes to their parent
            int root = -1;
            foreach (var node in pairDict.Keys)
            {
                if (pairDict[node].Count == n - 1) // If a node is connected to all other nodes, it is the root
                {
                    root = node;
                    break;
                }
            }

            if (root == -1) return 0; // If no root is found, return 0

            int result = 1; // Initialize result to 1 as a unique result

            // Validate the tree structure
            foreach (var node in pairDict.Keys)
            {
                if (node == root) continue; // Skip the root node

                int parent = -1;
                int parentDegree = int.MaxValue;

                foreach (var neighbor in pairDict[node])
                {
                    int neighborDegree = pairDict[neighbor].Count; // Get the degree of the neighbor node
                    int nodeDegree = pairDict[node].Count; // Get the degree of the current node
                    if (neighborDegree >= nodeDegree && neighborDegree < parentDegree)
                    {
                        parent = neighbor; // Update the parent if the neighbor has a higher degree than the current node
                        parentDegree = neighborDegree; // Update the parent degree
                    }
                }

                if (parent == -1) return 0; // If no parent is found, return 0

                foreach (var neighbor in pairDict[node])
                {
                    if (neighbor ==  parent) continue; // Skip the parent node
                    if (!pairDict[parent].Contains(neighbor))
                        return 0; // If the parent does not contain the neighbor, return 0
                }

                if (pairDict[parent].Count == pairDict[node].Count)
                    result = 2; // If the parent and node have the same degree, set result to 2
            }

            return result; // Return the result: 0, 1, or 2
        }
    }
}
