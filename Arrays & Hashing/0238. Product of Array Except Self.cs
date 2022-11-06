public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var output = new int[nums.Length];
        
        output[0] = 1;
        
        for(int i = 1; i < nums.Length; i++){
            // Multiply the number before and the nums[] starting from left
            output[i] = output[i - 1] * nums[i - 1];
        }
        
        int right = 1; // We now keep the multiplied value from right in 1 variable
        for(int i = nums.Length - 1; i >= 0; i--){
            output[i] *= right; // Multiply the left product by right
            right *= nums[i]; // multiply the right product by next value in nums
        }
        
        return output;
    }
    
    public int[] ProductExceptSelf2(int[] nums) {
        var answersLeft = new int[nums.Length];
        var answersRight = new int[nums.Length];
        var output = new int[nums.Length];
        
        answersLeft[0] = 1;
        answersRight[nums.Length - 1] = 1;
        
        for(int i = 1; i < nums.Length; i++){
            // Multiply the number before and the nums[] starting from left
            answersLeft[i] = answersLeft[i - 1] * nums[i - 1];
            answersRight[nums.Length - 1 - i] = answersRight[nums.Length - i] * nums[nums.Length - i];
            // Console.WriteLine($"L:{answersLeft[i]} - R:{answersRight[nums.Length - 1 - i]}");
        }
        
        for(int i = 0; i < nums.Length; i++){
            output[i] = answersLeft[i] * answersRight[i];
        }
        
        return output;
    }
}