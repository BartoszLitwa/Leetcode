public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;
        if(nums[left] > target)
            return left;
        else if(nums[right] < target)
            return right + 1;

        int mid = -1;
        while(left <= right){
            mid = (left + right) / 2;
            if(nums[mid] == target)
                return mid;
            else if(nums[mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return nums[mid] > target ? mid : mid + 1;
    }
}