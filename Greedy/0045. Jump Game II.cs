public class Solution {
    public int Jump(int[] nums) {
        int steps = 0;
        int left = 0, right = 0;
        
        // We know that if we reach second last item we can jump to the last one
        while(right < nums.Length - 1){ // Until we reach the last element
            int farthest = 0;
            for(int i = left; i <= right; i++){ // Iterate thru the window
                // i - from which elem we jump + nums[i] - how far we could jump
                farthest = Math.Max(farthest, i + nums[i]);
            }
            left = right + 1;
            right = farthest;
            steps++;
        }

        return steps;
    }
}