public class Solution {
    public int Trap(int[] height) {
        if(height.Length < 1)
            return 0;
        // 1. Find the highest point
        int left = 0, right = height.Length - 1;
        int leftMax = height[left], rightMax = height[right];
        int res = 0;

        while(left < right){ // move until left == right
            if(leftMax <= rightMax){ // move left
                // move left to the right and update the leftMax value
                leftMax = Math.Max(leftMax, height[++left]);
                res += leftMax - height[left]; // add the water
            } else { // move right
                // move right to the left and update the rightMax value
                rightMax = Math.Max(rightMax, height[--right]);
                res += rightMax - height[right]; // add the water
            }
        }

        return res;
    }
}