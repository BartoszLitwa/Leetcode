public class Solution {
    // Graph Algo solution
    public int NumIslands(char[][] grid) {
        int r = grid.Length, c = grid[0].Length;
        if(r == 0 || c == 0)
            return 0;
        
        int number = 0;
        var hset = new HashSet<(int, int)>();
        var directions = new int[][] {new int[]{0, 1}, new int[]{1, 0},
                                                  new int[]{-1, 0}, new int[]{0, -1}};
        
        for(int i = 0; i < r; i++){
            for(int j = 0; j < c; j++){
                var ij = (i, j);
                if(grid[i][j] == '1' && !hset.Contains(ij)){
                    // BFS Algo
                    var queue = new Queue<(int, int)>();
                    queue.Enqueue(ij);

                    while(queue.Count > 0){
                        var deq = queue.Dequeue();

                        for(int dir = 0; dir < directions.Length; dir++){
                            int a = deq.Item1 + directions[dir][0];
                            int b = deq.Item2 + directions[dir][1];
                            var ab = (a, b);
                            // Check if we already visited this part and if its not water
                            if(a < 0 || a >= r || b < 0 || b >= c || grid[a][b] == '0' || hset.Contains(ab)){
                                continue;
                            }
                            
                            hset.Add(ab); // Add to the visited parts
                            queue.Enqueue(ab); // Add it to queue for further processing
                        }
                    }
                    // Increase the number of visited Islands
                    number++;
                }
            }
        }
        
        return number;
    }
}