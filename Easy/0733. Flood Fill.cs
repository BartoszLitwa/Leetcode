public class Solution {
    // Iterative - BFS
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        // Dont do anything if current color is the same - there is no point;
        if(image[sr][sc] == color)
            return image;
        
        var prevColor = image[sr][sc];
        var queue = new Queue<int[]>();
        queue.Enqueue(new int[] {sr, sc});
        while(queue.Count > 0){
            // Get the first element from the queue
            var d = queue.Dequeue();
            
            // Check if it is in the bounds of the image and if it has the same color as the starting point
            if(d[0] < 0 || d[1] < 0 || d[0] >= image.Length || d[1] >= image[0].Length ||
               image[d[0]][d[1]] != prevColor)
            continue;
            
            // Change the color
            image[d[0]][d[1]] = color;
            
            // Add every 4 directional neighbour to the queue
            queue.Enqueue(new int[] {d[0] - 1, d[1]});
            queue.Enqueue(new int[] {d[0] + 1, d[1]});
            queue.Enqueue(new int[] {d[0], d[1] - 1});
            queue.Enqueue(new int[] {d[0], d[1] + 1});
        }
        
        return image;
    }
    
    // Recursive - DFS
    public int[][] FloodFill2(int[][] image, int sr, int sc, int color) {
        // Dont do anything if current color is the same - there is no point;
        if(image[sr][sc] == color)
            return image;
        
        fill(image, sr, sc, image[sr][sc], color);
        return image;
    }
    
    private void fill(int[][] image, int sr, int sc, int prevColor, int color){
        if(sr < 0 || sc < 0 || sr >= image.Length || sc >= image[0].Length || image[sr][sc] != prevColor)
            return;
        
        image[sr][sc] = color;
        fill(image, sr, sc - 1, prevColor, color); // To the left
        fill(image, sr - 1, sc, prevColor, color); // To the top
        fill(image, sr, sc + 1, prevColor, color); // To the right
        fill(image, sr + 1, sc, prevColor, color); // To the bottom
    }
}