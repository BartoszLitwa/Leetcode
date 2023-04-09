public class Solution {
    public int SwimInWater(int[][] grid) {
        var direction = new List<(int x, int y)>{ (0, 1), (0, -1), (1, 0), (-1, 0) };

        var len = grid.Length;
        var visited = new HashSet<(int x, int y)>();
        var sorted = new SortedDictionary<int, List<(int x, int y)>>();
        visited.Add((0, 0));
        sorted.Add(grid[0][0], new List<(int x, int y)> { (0, 0) });

        while(sorted.Count > 0){
            var pop = sorted.First(); // Get the first element - the lowest key
            sorted.Remove(pop.Key); // Remove the first element

            foreach(var (x, y) in pop.Value){ // Iterate through the list of coordinates with lowest key
                if(x == len - 1 && y == len - 1) // If we have reached the bottom right corner, return the key
                    return pop.Key;

                foreach(var (dx, dy) in direction){ // Iterate through the 4 directions
                    int row = x + dx, col = y + dy; // Get the next coordinates
                    if(row < 0 || col < 0 || row >= len || col >= len 
                        || visited.Contains((row, col))) // If the coordinates are out of bounds or we have already visited them,
                        continue;

                    visited.Add((row, col)); // Mark the coordinates as visited
                    var key = Math.Max(pop.Key, grid[row][col]); // Get the key
                    if(sorted.ContainsKey(key)) // Add the coordinates to the sorted dictionary
                        sorted[key].Add((row, col));
                    else
                        sorted.Add(key, new List<(int x, int y)> { (row, col) });
                }
            }
        }

        return -1; // Should be never reached
    }
}