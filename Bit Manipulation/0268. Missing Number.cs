public class Solution {
    public int MissingNumber(int[] nums) {
        // XOR return 1 only when 2 bits are different
        // XOR all the ints in nums
        var sumNums = nums.Aggregate((a, b) => a ^ b);
        var sumAll = Enumerable.Range(1, nums.Length).Aggregate((a, b) => a ^ b);
        // Return the XOR of 2 sums - will return the bits that are different
        return sumNums ^ sumAll;
    }
}