public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        var grid = new int[text1.Length + 1, text2.Length + 1]; // Create grid
        for(int i = 0; i < text1.Length + 1; i++){
            for(int j = 0; j < text2.Length + 1; j++){
                grid[i, j] = 0; // Initialize grid
            }
        }

        for(int i = text1.Length - 1; i >= 0; i--){
            for(int j = text2.Length - 1; j >= 0; j--){
                // If the characters are the same, add 1 to the diagonal
                    grid[i, j] = text1[i] == text2[j] ? // else take the max of the right and bottom
                        1 + grid[i + 1, j + 1] : Math.Max(grid[i, j + 1], grid[i + 1, j]);
            }
        }

        return grid[0, 0]; // Return the top left value
    }
}