public class Solution {
    public int MaxSubArray(int[] nums) {
	int curSum = 0;
    int maxSub = nums[0];

	for (int i=0; i<nums.Length; i++) {
		if(curSum < 0){
            curSum = 0;
        }
        curSum += nums[i]; 
        maxSub = Math.Max(maxSub, curSum);
	}
	return maxSub;
}
}