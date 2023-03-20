public class Solution {
    public int[] SortedSquares(int[] nums) {
        int start = 0, end = nums.Length - 1;
        int resIndex = end;
        var res = new int[nums.Length]; // Setup new res array
        while(start <= end){
            res[resIndex--] = Math.Abs(nums[start]) > Math.Abs(nums[end]) // Compare absolute values
                ? (int)Math.Pow(nums[start++], 2) : (int)Math.Pow(nums[end--], 2); // Add the bigger one to the end of the res array
        }
        return res;
    }
}