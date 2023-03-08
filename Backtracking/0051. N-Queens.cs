public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        var cols = new HashSet<int>();
        var posDiagonal = new HashSet<int>(); // (row + col)
        var negDiagonal = new HashSet<int>(); // (row - col)

        var res = new List<IList<string>>();
        var emptyRow = string.Concat(Enumerable.Repeat(".", n)); // Create empty row
        var board = Enumerable.Repeat(emptyRow, n).ToList(); // Create empty board

        Backtrack(0);

        return res;

        void Backtrack(int row){
            if(row == n){ // Found a solution
                var copy = new List<string>(board); // Create a copy
                res.Add(copy); // Add to result
                return;
            }

            for(int col = 0; col < n; col++){
                if(cols.Contains(col) || posDiagonal.Contains(row + col) || negDiagonal.Contains(row - col))
                    continue;

                // Add used cols and diagonals
                cols.Add(col);
                posDiagonal.Add(row + col);
                negDiagonal.Add(row - col);
                // String are immutable in c#
                var sb = new StringBuilder(board[row]);
                sb[col] = 'Q';
                board[row] = sb.ToString();
                // Call backtrack with new row
                Backtrack(row + 1);
                // Cleanup - remove used cols and diagonals
                cols.Remove(col);
                posDiagonal.Remove(row + col);
                negDiagonal.Remove(row - col);
                sb[col] = '.';
                board[row] = sb.ToString();
            }
        }
    }
}