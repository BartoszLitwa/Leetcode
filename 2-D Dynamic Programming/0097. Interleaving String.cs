public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        if(s1.Length + s2.Length != s3.Length) // If the length of s1 + s2 is not equal to s3, return false
            return false;

        var cached = new bool[s1.Length + 1][]; // Create a 2-D array to cache the result
        for(int i = 0; i < cached.Length; i++){
            cached[i] = new bool[s2.Length + 1];
        }
        cached[s1.Length][s2.Length] = true; // Set the bottom right corner to true

        for(int i = s1.Length; i >= 0; i--){
            for(int j = s2.Length; j >= 0; j--){
                if((i < s1.Length && s1[i] == s3[i + j] && cached[i + 1][j]) || // If letter or s1 matches s3
                   (j < s2.Length && s2[j] == s3[i + j] && cached[i][j + 1])) { // If letter of s2 matches s3
                    cached[i][j] = true;
                   }
            }
        }
        // Take the top left corner
        return cached[0][0];
    }

    private Dictionary<(int i, int j), bool> cached;
    public bool IsInterleave2(string s1, string s2, string s3) {
        cached = new Dictionary<(int i, int j), bool>();

        if(s1.Length + s2.Length != s3.Length)
            return false;

        return Helper2(0, 0, s1, s2, s3);
    }

    private bool Helper2(int i, int j, string s1, string s2, string s3){
        if(i == s1.Length && j == s2.Length) // If both i and j reach the end of s1 and s2,
            return true;
        if(cached.ContainsKey((i, j))) // If the result is cached, return it
            return cached[(i, j)];
        // If the letter of s1 matches s3, and the rest of s1 and s2 matches s3
        if(i < s1.Length && s1[i] == s3[i + j] && Helper2(i + 1, j, s1, s2, s3))
            return true;
        if(j < s2.Length && s2[j] == s3[i + j] && Helper2(i, j + 1, s1, s2, s3))
            return true;

        cached[(i, j)] = false; // Cache the result
        return false;
    }
}