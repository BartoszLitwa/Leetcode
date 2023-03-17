public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int targetFinal) {
        Array.Sort(nums); // Sort the input array O(n log n)
        // To make sure duplicates are next to each other
        var res = new List<IList<int>>();
        var found = new List<int>();
        KSum(4, 0, targetFinal);

        return res;

        void KSum(int k, int start, long target){
            if(k == 2){ // If we are looking for 2 numbers
                TwoSum(start, target);
            } else {
                // Why nums.Length - k + 1?
                // Because we need to have at least k - 1 numbers left
                for(int i = start; i < nums.Length - k + 1; i++){ 
                    if(i > start && nums[i] == nums[i - 1]) // Same number as before
                        continue;

                    found.Add(nums[i]); // Add current number to found list
                    KSum(k - 1, i + 1, target - nums[i]); // Recurse
                    found.Remove(nums[i]); // Remove current number from found list
                }
            }
        }

        void TwoSum(int start, long target){
            int left = start, right = nums.Length - 1;
            while(left < right){
                var sum = nums[left] + nums[right];
                if(sum > target){ // If target value is bigger
                    right--;
                } else if(sum < target){ // If target value is lower
                    left++;
                } else {
                    res.Add(new List<int>{found[0], found[1], nums[left], nums[right]});
                    left++; // Increase left index
                    while(left < right && nums[left]  == nums[left - 1]){ // Same number as before
                        left++;
                    }
                }
            }
        }
    }
}