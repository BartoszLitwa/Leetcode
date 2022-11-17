public class Solution {
    public bool SearchMatrix(int[][] matrix, int target){
        int top = 0, bot = matrix.Length - 1; // Rows
        
        while(top <= bot){
            int row = (top + bot) / 2;
            if(target > matrix[row][matrix[0].Length - 1]){ // target is bigger than biggest value in this row
                top = row + 1;
            } else if (target < matrix[row][0]){ // target is smaller than currents row smalles value
                bot = row - 1;
            } else { // target is this row probably
                break;
            }
        }
        
        if(top > bot) // Invalid
            return false;
        
        int resRow = (top + bot) / 2;
        int left = 0, right = matrix[0].Length - 1;
        while(left <= right){
            int mid = (left + right) / 2;
            if(matrix[resRow][mid] == target){
                return true;
            } else if (matrix[resRow][mid] > target) { // Target is on the left
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        
        return false;
    }
    
    public bool SearchMatrix2(int[][] matrix, int target) {
        int n = matrix.Length * matrix[0].Length;
        int left = 0, right = n - 1;
        
        while(left <= right){
            int midpoint = (left + right) / 2;
            int val = matrix[midpoint / matrix[0].Length][midpoint % matrix[0].Length]; // matrix[0].Length - cols
            Console.WriteLine(val);
            if(val == target){
                return true;
            } else if (val > target){ // on the right of the midpoint
                right = midpoint - 1;
            } else{
                left = midpoint + 1;
            }
        }
        
        return false;
    }
}