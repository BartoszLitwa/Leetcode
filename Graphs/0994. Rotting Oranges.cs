public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length, cols = grid[0].Length;
        int freshOranges = 0;
        var que = new Queue<(int X, int Y)>();
        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(grid[r][c] == 1) // Fresh oranges
                    freshOranges++;
                else if(grid[r][c] == 2) // Rotten Oranges
                    que.Enqueue((r, c));
            }
        }

        var dirs = new List<(int X, int Y)>{
            (0, 1), (0, -1), (1, 0), (-1, 0)
        };

        int time = 0;
        // Until we have any rotten Oranges and freshOranges
        while(que.Count > 0 && freshOranges > 0){
            var len = que.Count; // Save the length since we will be adding
            for(int i = 0; i < len; i++){ // Dequeu every elem
                (int X, int Y) cell = que.Dequeue();
                foreach(var dir in dirs){
                    (int X, int Y) cur = (cell.X + dir.X, cell.Y + dir.Y);

                    if(cur.X < 0 || cur.X >= rows || cur.Y < 0 || cur.Y >= cols // Out of bounds
                        || grid[cur.X][cur.Y] != 1) // it is not a fresh Orange 
                        continue;

                    que.Enqueue(cur); // Add it to queue for later use
                    grid[cur.X][cur.Y] = 2; // Set the currently fresh to rotten Orange
                    freshOranges--; // Decrement still available oranges
                }
            }

            time++; // Increment the time
        }

        // Only return time when there are not any fresh Oranges left
        return freshOranges == 0 ? time : -1;
    }

    private void DFS(int x, int y){

    }
}