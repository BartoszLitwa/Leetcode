public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var hSet = new List<int>();
        
        for(int i = 0; i < nums.Length; i++){
            if(hSet.Contains(nums[i])){
                return new int[] { hSet.IndexOf(nums[i]), i };
            }
            
            hSet.Add(target - nums[i]);
        }
        
        return new int[] {0, 0};
    }
    
    public int[] TwoSum2(int[] nums, int target) {
        var dict = new Dictionary<int, int>();
        
        for(int i = 0; i < nums.Length; i++){
            if(dict.ContainsKey(target - nums[i])){
                return new int[] { dict[target - nums[i]], i };
            }
            
            if(!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], i);
        }
        
        return new int[] {0, 0};
    }
    
    public int[] TwoSum3(int[] nums, int target) {
        for(int i = 0; i < nums.Length; i++){
            for(int j = 0; j < nums.Length; j++){
                if(i == j)
                    continue;
                
                if(nums[i] + nums[j] == target){
                    return new int[] {i , j};
                }
            }
        }
        
        return new int[] {0, 0};
    }
}