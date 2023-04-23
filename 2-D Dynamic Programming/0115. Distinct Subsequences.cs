public class Solution {
    public int NumDistinct(string s, string t) {
        var dir = new Dictionary<(int i, int j), int>();
        
        return Helper(0, 0);

        int Helper(int i, int j){
            if(t.Length == j) // reached the end of subsequence
                return 1;
            if(s.Length == i) // reached the end of string
                return 0;
            
            if(dir.ContainsKey((i, j))) // memoization
                return dir[(i, j)];

            if(s[i] == t[j]){ // if the current char matches
                // 2 cases
                dir.Add((i, j), Helper(i + 1, j + 1) + Helper(i + 1, j));
            } else {
                dir.Add((i, j), Helper(i + 1, j)); // skip the current char
            }

            return dir[(i, j)]; // return the result
        }
    }
}