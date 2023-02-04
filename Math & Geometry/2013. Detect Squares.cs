public class DetectSquares {
    private Dictionary<(int X, int Y), int> dict;

    public DetectSquares() {
        dict = new Dictionary<(int X, int Y), int>();
    }
    
    public void Add(int[] point) {
        (int X, int Y) p = (point[0], point[1]);
        if(!dict.ContainsKey(p)) // Add point to dictionary
            dict.Add(p, 1);
        else // Increment point count
            dict[p]++;
    }
    
    public int Count(int[] point) {
        (int X, int Y) p = (point[0], point[1]);
        int res = 0;
        foreach(var (X, Y) in dict.Keys){ // Loop through all points
            // Check if we have a square and point is not the same
            if(Math.Abs(X - p.X) != Math.Abs(Y - p.Y) || X == p.X || Y == p.Y) 
                continue;
            // Check if we have the other two points
            if(dict.ContainsKey((X, p.Y)) && dict.ContainsKey((p.X, Y))){
                // Add the number of squares we can make - we can have multiple points at the same location
                res += dict[(X, p.Y)] * dict[(p.X, Y)] * dict[(X, Y)];
            }
        }
        return res;
    }
}

/**
 * Your DetectSquares object will be instantiated and called as such:
 * DetectSquares obj = new DetectSquares();
 * obj.Add(point);
 * int param_2 = obj.Count(point);
 */