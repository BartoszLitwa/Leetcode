public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int totalCells = rows * cols;
        
        List<List<int>> result = Enumerable
            .Repeat(0, rows)
            .Select(_ => Enumerable.Repeat(0, cols).ToList())
            .ToList();

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                int pos = (i * cols) + j + k;
                int newRow = (pos % totalCells) / cols;
                int newCol = (pos % totalCells) % cols;
                result[newRow][newCol] = grid[i][j];
            }
        }

        return result.Cast<IList<int>>().ToList();
    }
}