public class Solution {
    public int[] RunningSum(int[] nums) {
        for(int i = 1; i < nums.Length; i++){
            nums[i] += nums[i - 1];
        }
        
        return nums;
    }

    public int[] RunningSum2(int[] nums) {
        var output = new int[nums.Length];
        
        for(int i = 0; i < nums.Length; i++){
            int temp = 0;
            for(int j = 0; j <= i; j++){
                temp += nums[j];
            }
            output[i] = temp;
        }
        
        return output;
    }
}