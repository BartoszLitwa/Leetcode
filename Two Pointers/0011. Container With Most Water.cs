public class Solution {
    public int MaxArea(int[] height) {
        int left = 0, right = height.Length -1;
        int max = 0;
        while(left < right){
            // width = right - left index and height = min of left or right element height
            max = Math.Max(max, (right - left) * Math.Min(height[left], height[right]));
            
            if(height[left] < height[right]) // Move the index of the lower height
                left++;
            else
                right--;
        }
        
        return max;
    }
}