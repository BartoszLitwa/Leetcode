public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int[] newArray = new int[nums.Length * 2];

        int globalCounter = 0;
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < nums.Length; j++)
            {
                int index = globalCounter + j;
                newArray[index] = nums[j];
            }
            globalCounter += nums.Length;
        }

        return newArray;
    }

    public int[] GetConcatenation3(ReadOnlySpan<int> nums) {
        Span<int> res = stackalloc int[nums.Length*2];

        for (int i = 0, j=nums.Length; i < nums.Length; i++, j++)
        {
            res[i] = nums[i];
            res[j] = nums[i];
        }

        GC.Collect();

        return res.ToArray();
    }

    public int[] GetConcatenation2(int[] nums) {
        var n = nums.Length;
        var ans = new int[n * 2];
        for(int i = 0; i < n; i++){
            ans[i] = nums[i];
            ans[i + n] = nums[i];
        }
        return ans;
    }
}