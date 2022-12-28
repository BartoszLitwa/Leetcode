public class Solution {
    private int rows, cols;
    private int max;
    private HashSet<(int X, int Y)> visited;
    private int[][] grid;
    public int MaxAreaOfIsland(int[][] grid) {
        rows = grid.Length;
        cols = grid[0].Length;
        this.grid = grid;
        visited = new HashSet<(int X, int Y)>();

        for(int x = 0; x < rows; x++){
            for(int y = 0; y < cols; y++){
                max = Math.Max(max, DFS(x, y));
            }
        }

        return max;
    }

    private int DFS(int x, int y){
        (int X, int Y) cor = (x, y);
        if(x < 0 || x >= rows || y < 0 || y >= cols || // Out of bands
         visited.Contains(cor) || grid[x][y] == 0) // Not island or visited already
         return 0;

        visited.Add(cor);

        return (1 + DFS(x + 1, y) + DFS(x - 1, y)
         + DFS(x, y + 1) + DFS(x, y - 1));
    }
}