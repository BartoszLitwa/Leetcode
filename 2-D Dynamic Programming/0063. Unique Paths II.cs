public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int cols = obstacleGrid.Length, rows = obstacleGrid[0].Length;
        int[] dp = new int[rows];
        dp[rows - 1] = 1;

        for(int c = cols - 1; c >= 0; --c){ // bottom to top solution
            for(int r = rows - 1; r >= 0; --r){
                if(obstacleGrid[c][r] == 1) // Obstacle
                    dp[r] = 0;
                else if(r + 1 < rows) // Not out of bounds
                    dp[r] += dp[r + 1];
            }
        }
        return dp[0];
    }
}