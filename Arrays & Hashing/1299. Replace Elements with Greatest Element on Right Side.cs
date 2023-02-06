public class Solution {
    public int[] ReplaceElements(int[] arr) {
        var maxRight = new int[arr.Length]; // Create array to store max right values
        maxRight[arr.Length - 1] = -1; // Set last value to -1

        for(int i = arr.Length - 2; i >= 0; i--){
            // Set max right value to the max of the next max right value and the next value
            maxRight[i] = Math.Max(maxRight[i + 1], arr[i + 1]);
        }

        return maxRight;
    }
}