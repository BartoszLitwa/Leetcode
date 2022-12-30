public class Solution {
    private int rows, cols;

    // Reverse Thinking
    public void Solve(char[][] board) {
        rows = board.Length;
        cols = board[0].Length;

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(board[r][c] == 'O' && ((r == 0 || r == rows - 1) ||
                 (c == 0 || c == cols - 1))){ // Check only border cells
                    DFS(r, c, board); // Run DFS and set the uncaptured regions
                }
            }
        }

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(board[r][c] == 'O'){ // Remove every captured region
                    board[r][c] = 'X';
                } else if(board[r][c] == 'T'){ // Revert the uncaptured regions
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void DFS(int r, int c, char[][] board){
        if(r < 0 || r >= rows || c < 0 || c >= cols || board[r][c] != 'O')
            return;

        board[r][c] = 'T';
        DFS(r + 1, c, board);
        DFS(r - 1, c, board);
        DFS(r, c + 1, board);
        DFS(r, c - 1, board);
    }
}