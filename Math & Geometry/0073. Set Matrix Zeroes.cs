public class Solution {
    public void SetZeroes(int[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        var first = false; // First row has 0

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(matrix[r][c] == 0){ // Found 0
                    matrix[0][c] = 0; // Mark column
                    if(r > 0){ // Mark row
                        matrix[r][0] = 0;
                    } else { // First row
                        first = true;
                    }
                }
            }
        }

        for(int r = 1; r < rows; r++){
            for(int c = 1; c < cols; c++){ // Skip first row and column
                if(matrix[0][c] == 0 || matrix[r][0] == 0){ // Marked column or row
                    matrix[r][c] = 0; // Set to 0
                }
            }
        }

        if(matrix[0][0] == 0){ // Marked first row and column
            for(int r = 0; r < rows; r++){ // Set first column to 0
                matrix[r][0] = 0;
            }
        }

        if(first){ // Marked first row
            for(int c = 0; c < cols; c++){ // Set first row to 0
                matrix[0][c] = 0;
            }
        }
    }
}