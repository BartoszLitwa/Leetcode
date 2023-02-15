public class Solution {
    private Dictionary<(int Index, int total), int> dict;

    public int FindTargetSumWays(int[] nums, int target) {
        dict = new Dictionary<(int Index, int total), int>();

        return Helper(0, 0, nums, target);
    }

    private int Helper(int index, int total, int[] nums, int target){
        if(index == nums.Length)
            return total == target ? 1 : 0;

        if(dict.ContainsKey((index, total)))
            return dict[(index, total)];

        dict.Add((index, total), Helper(index + 1, total + nums[index], nums, target)
                             + Helper(index + 1, total - nums[index], nums, target));
        return dict[(index, total)];
    }
}