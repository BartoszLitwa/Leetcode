public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int res = 0;
        int m = grid.Length, n = grid[0].Length;
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 1){
                    //Unconnected cell
                    res += 4;
                    
                    //check connection to the left
                    if(j > 0 && grid[i][j - 1] == 1) res -= 1;
                    
                    //check connection up
                    if(i > 0 && grid[i-1][j] == 1) res -= 1;
                    
                    //check connection to the right
                    if(j < n - 1 && grid[i][j + 1] == 1) res -= 1;
                    
                    //check bottom connection
                    if(i < m - 1 && grid[i+1][j] == 1) res -= 1;
                }
            }
        }
        return res;
    }

    public int IslandPerimeter2(int[][] grid) {
        var visited = new HashSet<(int x, int y)>();

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 1){ // Find the first part of the island
                    return Helper(i, j); // Return the perimeter of the island
                }
            }
        }

        return 0;
        
        int Helper(int i, int j){
            // Out of bounds or not an island
            if(i >= grid.Length || j >= grid[0].Length || i < 0 || j < 0 || grid[i][j] == 0)
                return 1;

            if(visited.Contains((i, j))) // Already visited
                return 0;

            visited.Add((i, j)); // Mark as visited
            // Return the sum of the perimeters of the 4 directions
            return Helper(i - 1, j) + Helper(i + 1, j) + Helper(i, j - 1) + Helper(i, j + 1);
        }
    }
}