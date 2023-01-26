public class Solution {
    public void Rotate(int[][] matrix) {
        // Indexes of corner cells
        int left = 0, right = matrix.Length - 1;
        int top = 0, bottom = matrix[0].Length - 1;

        // Top Left is [0,0]
        while(left < right){
            for(int i = 0; i < (right - left); i++){ // Iterate each rotation per row
                top = left;
                bottom = right;

                int topLeft = matrix[top][left + i]; // save top left to temp variable
                // Reverse order - rotate 4 pixels in each current corner
                matrix[top][left + i] = matrix[bottom - i][left]; // bottom left to top left
                matrix[bottom - i][left] = matrix[bottom][right - i]; // bottom right to bottom left
                matrix[bottom][right - i] = matrix[top + i][right]; // top right to bottom right
                matrix[top + i][right] = topLeft; // Set the top right
            }
            // Move to next inner square
            left++;
            right--;
        }
    }
}