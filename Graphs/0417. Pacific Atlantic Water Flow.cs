public class Solution {
    private int rows = 0, cols = 0;
    private int[][] heights;

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        rows = heights.Length;
        cols = heights[0].Length;
        this.heights = heights;
        var pacific = new HashSet<(int X, int Y)>();
        var atlantic = new HashSet<(int X, int Y)>();

        for(int i = 0; i < cols; i++){ // Iterate through each column
            DFS(0, i, heights[0][i], pacific);
            DFS(rows - 1, i, heights[rows - 1][i], atlantic);
        }

        for(int i = 0; i < rows; i++){ // Iterate through each row
            DFS(i, 0, heights[i][0], pacific);
            DFS(i, cols - 1, heights[i][cols - 1], atlantic);
        }

        var res = new List<IList<int>>();
        for(int x = 0; x < rows; x++){ // Brute Force check if given cell can reach both oceans
            for(int y = 0; y < cols; y++){
                (int X, int Y) cur = (x, y);
                if(pacific.Contains(cur) && atlantic.Contains(cur)){
                    res.Add(new List<int>() {x, y});
                }
            }
        }

        return res;
    }

    private void DFS(int x, int y, int prevHeight, HashSet<(int X, int Y)> ocean){
        (int X, int Y) cur = (x, y);
        if(ocean.Contains(cur) || x < 0 || x >= rows || y < 0 || y >= cols ||
         prevHeight > heights[x][y]){ // current height is lower
            return; // Out of bands or already visited
        }

        ocean.Add(cur);

        DFS(x + 1, y, heights[x][y], ocean);
        DFS(x - 1, y, heights[x][y], ocean);
        DFS(x, y + 1, heights[x][y], ocean);
        DFS(x, y - 1, heights[x][y], ocean);
    }
}