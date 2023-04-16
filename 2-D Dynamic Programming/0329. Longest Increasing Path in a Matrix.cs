public class Solution {
    private readonly List<(int r, int c)> dirs = new() 
        { (1, 0), (-1, 0), (0, 1), (0, -1) };

    public int LongestIncreasingPath(int[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        var lip = new Dictionary<(int x, int y), int>();

        int result = 1;
        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){ // Find the longest path starting from each cell
                // -1 There is no previous value, so its always gonna be bigger
                result = Math.Max(result, Helper(r, c, - 1));
            }
        }

        return result;

        int Helper(int r, int c, int prevVal){
            if(r < 0 || r >= rows || c < 0 || c >= cols // Out of bound
                || matrix[r][c] <= prevVal) // Not increasing
                return 0;

            if(lip.ContainsKey((r, c))) // Memoization
                return lip[(r, c)]; // Return already resolved value

            int res = 1;
            for(int i = 0; i < dirs.Count; i++){ // Try all directions
                // Add 1 to the result of the next cell
                res = Math.Max(res, 1 + Helper(r + dirs[i].r, c + dirs[i].c, matrix[r][c]));
            }
            lip.Add((r, c), res); // Memoization
            return res;
        } 
    }
}