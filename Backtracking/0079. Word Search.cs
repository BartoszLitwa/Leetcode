public class Solution {
    private int rows, cols;
    private string word;
    private char[][] board;
    private IList<(int Row, int Col)> path;

    public bool Exist(char[][] board, string word) {
        rows = board.Length;
        cols = board[0].Length;
        this.word = word;
        this.board = board;
        path = new List<(int Row, int Col)>();

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(DFS(r, c, 0)){ // Only when we found the path
                    return true;
                }
            }
        }

        return false;
    }

    private bool DFS(int row, int col, int i){
        if(i == word.Length) // we found it since i is 0 based indexing
            return true;

        (int Row, int Col) cur = (row, col);
        if(row < 0 || col < 0 || row >= rows || col >= cols) // Out of bounds
            return false;
        else if(word[i] != board[row][col]) // Letter is not correct
            return false;
        else if(path.Contains(cur)) // We already visited it on our way
            return false;
        
        path.Add(cur); // Set it as out path
        // Check in every direction
        var res = (DFS(row + 1, col, i + 1) ||
                DFS(row - 1, col, i + 1) ||
                DFS(row, col + 1, i + 1) ||
                DFS(row, col - 1, i + 1));
        
        // Cleanup after
        path.Remove(cur);
        return res;
    }
}