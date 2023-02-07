public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        if(points.Length == 1) // No need to connect
            return 0;

        var list = new Dictionary<int, List<(int Cost, int Point)>>();
        for(int i = 0; i < points.Length; i++){
            for(int j = i + 1; j < points.Length; j++){
                // Manhattan distance
                int dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                if(list.ContainsKey(i)){
                    list[i].Add((dist, j));
                } else {
                    list.Add(i, new List<(int Cost, int Point)>{ (dist, j) });
                }
                // Add the reversed edge
                if(list.ContainsKey(j)){
                    list[j].Add((dist, i));
                } else {
                    list.Add(j, new List<(int Cost, int Point)>{ (dist, i) });
                }
            }
        }

        var res = 0;
        var visited = new HashSet<int>();
        var sort = new SortedDictionary<int, List<int>>(); // Cost, Point
        sort.Add(0, new List<int>(){ 0 }); // Start from 0
        while(visited.Count < points.Length){
            var lastItems = sort.First(); // Get the smallest cost
            int cost = lastItems.Key; // Get the cost
            int point = lastItems.Value[0]; // Get the first point
            if(lastItems.Value.Count == 1){ // Remove the cost if no more points
                sort.Remove(cost);
            } else { // Remove the point
                lastItems.Value.RemoveAt(0);
            }
            if(visited.Contains(point)) // Skip if visited
                continue;

            res += cost; // Add the cost
            visited.Add(point); // Mark as visited
            foreach(var nei in list[point]){ // Add the neighbors
                if(visited.Contains(nei.Point)) // Skip if visited
                    continue;

                if(sort.ContainsKey(nei.Cost)){ // Add the neighbor
                    sort[nei.Cost].Add(nei.Point); // Add the point
                } else { // Add the cost
                    sort.Add(nei.Cost, new List<int>(){ nei.Point });
                }
            }
        }

        return res;
    }
}