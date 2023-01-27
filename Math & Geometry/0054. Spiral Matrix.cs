public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        int left = 0, right = matrix[0].Length - 1;
        int top = 0, bottom = matrix.Length - 1;

        var res = new List<int>();
        while(left <= right && top <= bottom){
            // Get top row
            for(int i = left; i <= right; i++){
                res.Add(matrix[top][i]);
            }
            top++;

            // Get right column
            for(int i = top; i <= bottom; i++){
                res.Add(matrix[i][right]);
            }
            right--;
            if(!(left <= right && top <= bottom))
                break;

            // Get bottom row
            for(int i = right; i > left - 1; i--){
                res.Add(matrix[bottom][i]);
            }
            bottom--;

            // Get left column
            for(int i = bottom; i > top - 1; i--){
                res.Add(matrix[i][left]);
            }
            left++;
        }
        return res;
    }
}