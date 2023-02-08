public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var edges = new Dictionary<int, List<(int v, int w)>>();
        // Build the graph
        for(int i = 0; i < times.Length; i++){
            if(edges.ContainsKey(times[i][0])){ // Add the edge
                edges[times[i][0]].Add((times[i][1], times[i][2]));
            } else { // Add the node
                edges.Add(times[i][0], new List<(int v, int w)>{ (times[i][1], times[i][2]) });
            }
        }

        var res = 0;
        var visited = new HashSet<int>();
        var minHeap = new SortedDictionary<int, List<int>>(); // Path, nodes
        minHeap.Add(0, new List<int>{ k }); // Start from k node
        while(minHeap.Count > 0){ // While there are nodes to visit
            var item = minHeap.First(); // Get the smallest path
            var path = item.Key; // Get the path
            var node = item.Value.First(); // Get the first node
            if(item.Value.Count == 1){ // Remove the path if no more nodes
                minHeap.Remove(path);
            } else { // Remove the node
                item.Value.Remove(node);
            }

            if(visited.Contains(node)) // Skip if visited
                continue;

            visited.Add(node); // Mark as visited
            res = Math.Max(res, path); // Update the max path

            if(!edges.ContainsKey(node)) // Skip if no neighbour edges
                continue;

            foreach(var e in edges[node]){ // Add the neighbors
                if(visited.Contains(e.v)) // Skip if visited
                    continue;

                // We want to keep absolute path, so we can't use visited.Contains(e.v)
                if(minHeap.ContainsKey(path + e.w)){ // Add the neighbor
                    minHeap[path + e.w].Add(e.v);
                } else {
                    minHeap.Add(path + e.w, new List<int>{ e.v });
                }
            }
        }
        // If all nodes are visited, return the max path
        return visited.Count == n ? res : -1;
    }
}