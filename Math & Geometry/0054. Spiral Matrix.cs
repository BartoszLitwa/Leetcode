public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        int left = 0, right = matrix[0].Length - 1;
        int top = 0, bottom = matrix.Length - 1;

        var res = new List<int>();
        while(left < right && top < bottom){
            Console.WriteLine("test");
            // Get top row
            for(int i = left; i <= right; i++){
                res.Add(matrix[top][i]);
            }
            // Get right column
            for(int i = top + 1; i <= bottom; i++){
                res.Add(matrix[i][right]);
            }
            // Get bottom row
            for(int i = right - 1; i >= left; i--){
                res.Add(matrix[bottom][i]);
            }
            // Get left column
            for(int i = bottom - 1; i > top; i--){
                res.Add(matrix[i][left]);
            }

            left++;
            right--;
            top++;
            bottom--;
        }
        return res;
    }
}